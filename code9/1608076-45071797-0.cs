    for (int i = 0; i < m_agentCollection.Count; i++)
    {
        if(m_agentCollection[i] is AgentMACD)
        {
             AgentMACD macdAgent = (AgentMACD)m_agentCollection[i];    
        }
        else if(m_agentCollection[i] is AgentRSI)       
        {
             AgentRSI rsiAgent = (AgentRSI)m_agentCollection[i];    
        }
    }
