using Cordinator.Application.Helpers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cordinator.Infrastructure.Persistence
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            await SeedDataAsync(context);
        }

        public static async Task SeedDataAsync(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            Console.WriteLine(!context.Teams.Any());
            if (!context.Teams.Any())
            {
                await context.WorkShifts.AddRangeAsync(GetWorkShifts());
                await context.Teams.AddRangeAsync(GetTeams());
                await context.Agents.AddRangeAsync(GetTeamAAgents());
                await context.Agents.AddRangeAsync(GetTeamBAgents());
                await context.Agents.AddRangeAsync(GetTeamCAgents());
                await context.Agents.AddRangeAsync(GetTeamOverflowAgents());
                await context.SaveChangesAsync();
            }
        }

        public static List<WorkShift> GetWorkShifts()
        {
            return new List<WorkShift>
            {
                new WorkShift
                {
                    Id = 1,
                    Name = "Day1",
                    StartTimeHour = 6,
                    EndTimeHour = 14
                },
                new WorkShift
                {
                    Id = 2,
                    Name = "Day1",
                    StartTimeHour = 14,
                    EndTimeHour = 22
                },
                new WorkShift
                {
                    Id = 3,
                    Name = "Night",
                    StartTimeHour = 22,
                    EndTimeHour = 6
                }
            };
        }

        public static List<Team> GetTeams()
        {
            return new List<Team>
            {
                new Team
                {
                    Id = 1,
                    WorkShiftId = 1,
                    TeamName = "Team-A"
                },
                new Team
                {
                    Id = 2,
                    WorkShiftId = 2,
                    TeamName = "Team-B"
                },
                new Team
                {
                    Id = 3,
                    WorkShiftId = 3,
                    TeamName = "Team-C"
                },
                new Team
                {
                    Id = 4,
                    WorkShiftId = null,
                    TeamName = "Team-Overflow"
                }
            };
        }

        public static List<Agent> GetTeamAAgents()
        {
            return new List<Agent>
            {
                new Agent
                {
                   Id = 1,
                   Seniority = Seniority.Lead,
                   TeamId = 1
                },
                new Agent
                {
                   Id = 2,
                   Seniority = Seniority.Mid,
                   TeamId = 1
                },
                new Agent
                {
                   Id = 3,
                   Seniority = Seniority.Mid,
                   TeamId = 1
                },
                new Agent
                {
                   Id = 4,
                   Seniority = Seniority.Junior,
                   TeamId = 1
                },

            };
        }

        public static List<Agent> GetTeamBAgents()
        {
            return new List<Agent>
            {
                new Agent
                {
                   Id = 5,
                   Seniority = Seniority.Lead,
                   TeamId = 2
                },
                new Agent
                {
                   Id = 6,
                   Seniority = Seniority.Mid,
                   TeamId = 2
                },
                new Agent
                {
                   Id = 7,
                   Seniority = Seniority.Junior,
                   TeamId = 2
                },
                new Agent
                {
                   Id = 8,
                   Seniority = Seniority.Junior,
                   TeamId = 2
                },

            };
        }

        public static List<Agent> GetTeamCAgents()
        {
            return new List<Agent>
            {
                new Agent
                {
                   Id = 9,
                   Seniority = Seniority.Mid,
                   TeamId = 3
                },
                new Agent
                {
                   Id = 10,
                   Seniority = Seniority.Mid,
                   TeamId = 3
                },
            };
        }

        public static List<Agent> GetTeamOverflowAgents()
        {
            return new List<Agent>
            {
                new Agent
                {
                   Id = 11,
                   Seniority = Seniority.Junior,
                   TeamId = 4
                },
                new Agent
                {
                   Id = 12,
                   Seniority = Seniority.Junior,
                   TeamId = 4
                },
                 new Agent
                {
                   Id = 13,
                   Seniority = Seniority.Junior,
                   TeamId = 4
                },
                  new Agent
                {
                   Id = 14,
                   Seniority = Seniority.Junior,
                   TeamId = 4
                },
                   new Agent
                {
                   Id = 15,
                   Seniority = Seniority.Junior,
                   TeamId = 4
                },
                    new Agent
                {
                   Id = 16,
                   Seniority = Seniority.Junior,
                   TeamId = 4
                },
            };
        }
    }
}
