using Cordinator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cordinator.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Team> Teams { get; set; }
        DbSet<Agent> Agents { get; set; }
        DbSet<AgentChat> AgentChats { get; set; }
        DbSet<WorkShift> WorkShifts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
