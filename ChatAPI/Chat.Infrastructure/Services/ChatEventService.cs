using Chat.Application.Common.Interfaces;
using Domain.Entities;
using MassTransit;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Infrastructure.Services
{
    public class ChatEventService: IChatEventService
    {
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;

        public ChatEventService(IConfiguration configuration, IBus bus)
        {
            _configuration = configuration;
            _bus = bus;
        }
        public async Task PublishChatInitiation(string connectionId)
        {
            Uri uri = new Uri($"{_configuration["RabbitMQHost:Url"]}/{_configuration["RabbitMQHost:QueueName"]}");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(new Message { ConnectionId = connectionId, SendTime = DateTime.UtcNow, Text = "SessionInitiate" });
        }
    }
}
