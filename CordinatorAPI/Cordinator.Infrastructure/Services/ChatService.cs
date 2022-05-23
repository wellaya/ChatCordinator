using Cordinator.Application.Common.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cordinator.Infrastructure.Services
{
    public class ChatService : IChatService
    {
        public async Task AgentConnectChat(string connectionId, int agentId)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/chatHub")
                .Build();
            await connection.StartAsync();

            await connection.InvokeAsync("JoinGroup", connectionId, agentId.ToString());
        }
    }
}
