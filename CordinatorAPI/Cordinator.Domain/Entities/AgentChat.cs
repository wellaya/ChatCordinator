using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cordinator.Domain.Entities
{
    public class AgentChat
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public string ConnectionId { get; set; }
        public virtual Agent Agent { get; set; }
    }
}
