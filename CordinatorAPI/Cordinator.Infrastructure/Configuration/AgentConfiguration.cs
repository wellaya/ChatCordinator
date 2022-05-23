using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cordinator.Infrastructure.Configuration
{
    public class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Team)
                .WithMany(x => x.Agents)
                .HasForeignKey(x => x.TeamId);
        }
    }
}
