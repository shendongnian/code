    for (int i = 0; i < agents.Count; i++)
    {
        list[i].Date = agents[i].PoliciesInForce.Daily[i].Date;
        list[i].PifCnt = agents[i].PoliciesInForce.Daily[i].PifCnt;
        list[i].NoPopPifCnt = agents[i].PoliciesInForce.Daily[i].NoPopPifCnt;
        list[i].PopPifCnt = agents[i].PoliciesInForce.Daily[i].PopPifCnt;
        list[i].CleanPopPifCount = agents[i].PoliciesInForce.Daily[i].CleanPopPifCount;
    }
