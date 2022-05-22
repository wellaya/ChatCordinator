using Chat.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Application.Chat.Commands.CreateChatSession
{
    public record CreateChatSessionCommand(string ConnectionId) : IRequest<ChatDto>;


    public class CreateChatSessionCommandHandler : IRequestHandler<CreateChatSessionCommand, ChatDto>
    {
        private readonly IChatEventService _chatEventService;
        public CreateChatSessionCommandHandler(IChatEventService chatEventService)
        {
            _chatEventService = chatEventService;
        }

        public async Task<ChatDto> Handle(CreateChatSessionCommand request, CancellationToken cancellationToken)
        {
            await _chatEventService.PublishChatInitiation(request.ConnectionId);

            return new ChatDto { ConnectionId = request.ConnectionId };
        }
    }
}
