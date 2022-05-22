using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cordinator.Domain.Entities
{
    public class Message
    {
        public string ConnectionId { get; set; }
        public DateTime SendTime { get; set; }
        public string Text { get; set; }
    }
}
