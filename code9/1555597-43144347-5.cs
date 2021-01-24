    List<NewAgent> newAgentList = new List<NewAgent>();
    
    foreach (var item in e.CmsData.Agents)
    {
        NewAgent newAgents = new ScoreBoardClientTest.NewAgent();
    
        newAgents.AgentName = item.AgName;
    
        newAgents.AgentExtension = item.Extension;
    
        newAgents.AgentDateTimeChange = ConvertedDateTimeUpdated;
    
        newAgents.AuxReasons = item.AuxReasonDescription;
    
        newAgents.LoginIdentifier = item.LoginId;
    
        newAgents.AgentState = item.WorkModeDirectionDescription;
    
        var timeSpanSince = DateTime.Now - item.DateTimeUpdated;
        newAgents.AgentDateTimeStateChange = timeSpanSince;
    
        newAgentList.Add(newAgents);
    }
    
    int breakCount = newAgentList.Sum(agent => 
        agent.AuxReasons.Count(reasons => 
            !string.IsNullOrEmpty(reasons) && reasons.StartsWith("Break")));
