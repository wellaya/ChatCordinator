using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cordinator.Application.Common.Interfaces
{
    public interface IChatService
    {
        Task AgentConnectChat(string connectionId, int agentId);
    }
}
