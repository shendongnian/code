        int sum = 0;
        List<CostEachActivity> templist = new List<CostEachActivity>();           
        foreach (CostEachActivity cea in dka)
        {
            if (cea.activityID == activityID)
                templist.Add(cea);
        }
    
        foreach(var item in tempList)
        {
            sum += item.Amount;
        }
