    for (int i = 0; i < m_agentCollection.Count; i++)
    {
       var agent = m_agentCollection[i];
       if (agent is AgentMACD)
       {
          AgentMACD macdAgent = agent as AgentMACD;
       }
       else if (agent is AgentRSI)
       {
         AgentRSI rsiAgent = agent as AgentRSI;
       }
    }
