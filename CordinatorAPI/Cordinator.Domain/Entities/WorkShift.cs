using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cordinator.Domain.Entities
{
    public class WorkShift
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StartTimeHour { get; set; }
        public int EndTimeHour { get; set; }
    }
}
