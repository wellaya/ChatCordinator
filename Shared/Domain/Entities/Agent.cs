using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Agent
    {
        public Agent()
        {
            AgentChats = new HashSet<AgentChat>();
        }
        public int Id { get; set; }
        public double Seniority { get; set; }
        public int TeamId { get; set; }        
        public virtual Team Team { get; set; }
        public ICollection<AgentChat> AgentChats { get; set; }
    }
}
