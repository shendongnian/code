    foreach (var agent in m_agentCollection)
        {
            if (agent is AgentMACD)
            {
                AgentMACD macdAgent = agent as AgentMACD;
            }
            else if (agent is AgentRSI)
            {
                AgentRSI rsiAgent = agent as AgentRSI;
            }
        }
