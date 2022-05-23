using Cordinator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cordinator.Infrastructure.Configuration
{
    public class AgentChatConfiguration : IEntityTypeConfiguration<AgentChat>
    {
        public void Configure(EntityTypeBuilder<AgentChat> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Agent)
                .WithMany(x => x.AgentChats)
                .HasForeignKey(x => x.AgentId);
        }
    }
}
