using Chat.API.Hubs;
using Chat.Application.Chat.Commands.CreateChatSession;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ApiControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        public ChatController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task InitChat(CreateChatSessionCommand request)
        {
            await _hubContext.Groups.AddToGroupAsync(request.ConnectionId, request.ConnectionId);
            await Mediator.Send(request);
        }
        
    }
}
