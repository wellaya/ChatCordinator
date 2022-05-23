using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cordinator.Application.Helpers
{
    public static class AgentSelectHelper
    {
        public static Agent SelectAvailableAgent(this List<Agent> agents)
        {
            double juniorCap = 0, midCap = 0, seniorCap = 0, leadCap = 0;

            foreach (var agent in agents)
            {
                switch (agent.Seniority)
                {
                    case 0.4:
                        juniorCap += 0.4 * 10;
                        break;
                    case 0.6:
                        midCap += 0.6 * 10;
                        break;
                    case 0.8:
                        seniorCap += 0.8 * 10;
                        break;
                    case 0.5:
                        leadCap += 0.5 * 10;
                        break;
                    default:
                        break;
                }
            }

            Agent selectedAgent = null;

            agents = agents.OrderBy(x => x.AgentChats.Count).ToList();

            if (agents.Any(x => x.Seniority == Seniority.Junior && x.AgentChats.Count < juniorCap))
            {
                selectedAgent = agents.FirstOrDefault(x => x.Seniority == Seniority.Junior && x.AgentChats.Count < juniorCap);
            }
            else if (agents.Any(x => x.Seniority == Seniority.Mid && x.AgentChats.Count < midCap))
            {
                selectedAgent = agents.FirstOrDefault(x => x.Seniority == Seniority.Mid && x.AgentChats.Count < midCap);
            }
            else if (agents.Any(x => x.Seniority == Seniority.Senior && x.AgentChats.Count < seniorCap))
            {
                selectedAgent = agents.FirstOrDefault(x => x.Seniority == Seniority.Senior && x.AgentChats.Count < seniorCap);
            }
            else
            {
                selectedAgent = agents.FirstOrDefault(x => x.Seniority == Seniority.Lead && x.AgentChats.Count < leadCap);
            }

            return selectedAgent;
        }
    }

    public static class Seniority
    {
        public static readonly double Junior = 0.4;
        public static readonly double Mid = 0.6;
        public static readonly double Senior = 0.8;
        public static readonly double Lead = 0.5;
    }
}
