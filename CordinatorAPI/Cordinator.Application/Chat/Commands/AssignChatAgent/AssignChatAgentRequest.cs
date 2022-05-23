using Cordinator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cordinator.Application.Chat.Commands.AssignChatAgent
{
    public class AssignChatAgentRequest
    {
        public Message Message { get; set; }
    }
}
