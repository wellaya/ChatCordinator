using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cordinator.Domain.Entities
{
    public class Team
    {
        public Team()
        {
            Agents = new HashSet<Agent>();
        }

        public int Id { get; set; }
        public string TeamName { get; set; }

        public int? WorkShiftId { get; set; }
        public virtual WorkShift WorkShift { get; set; }
        public virtual ICollection<Agent> Agents { get; set; }
    }
}
