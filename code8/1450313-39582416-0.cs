     List<agent> Agents = new List<agent>();
    
        foreach (Agent A in Agents)
        {
            foreach (Agent B in Agents)
            {
                if (A.ID == B.ID)
                {
                Agents.Remove(B)
                }
            }
        }
