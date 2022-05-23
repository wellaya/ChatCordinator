using Cordinator.Application.Common.Interfaces;
using Cordinator.Domain.Entities;
using Cordinator.Domain.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cordinator.Application.Chat.Commands.AssignChatAgent
{
    public class AssignChatAgentCommand : IRequest
    {
        public Message Message { get; set; }
    }


    public class AssignChatAgentCommandHandler : IRequestHandler<AssignChatAgentCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IChatService _chatService;

        public AssignChatAgentCommandHandler(IApplicationDbContext context, IChatService chatService)
        {
            _context = context;
            _chatService = chatService;
        }

        public async Task<Unit> Handle(AssignChatAgentCommand request, CancellationToken cancellationToken)
        {
            // current hour 24 hours
            int hour = DateTime.Now.Hour;
            // active workshift
            var shift = _context.WorkShifts.Where(x => (x.StartTimeHour <= hour && x.EndTimeHour > hour && x.StartTimeHour < x.EndTimeHour) ||
            (x.EndTimeHour < x.StartTimeHour && ((x.StartTimeHour <= hour && hour < 24) || (x.EndTimeHour > hour && hour >= 0)))).FirstOrDefault();

            //working team
            var team = _context.Teams.Where(x => x.WorkShiftId == shift.Id).FirstOrDefault();

            var agents = team.Agents.Where(x => x.AgentChats.Count < 10).ToList();

            var selectedAgent = agents.SelectAvailableAgent();
            selectedAgent.AgentChats.Add(new AgentChat { ConnectionId = request.Message.ConnectionId });

            var result = await _context.SaveChangesAsync(cancellationToken);

            await _chatService.AgentConnectChat(request.Message.ConnectionId, selectedAgent.Id);
            return Unit.Value;
        }
    }
}
