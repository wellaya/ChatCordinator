using Cordinator.Domain.Entities;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cordinator.API.Consumers
{
    public class ChatConsumer : IConsumer<Message>
    {
        private ISender _mediator = null!;
        public ChatConsumer(ISender mediator)
        {
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<Message> context)
        {
            var data = context.Message;
            //Validate the Ticket Data
            //Store to Database
            //Notify the user via Email / SMS
        }
    }
}
