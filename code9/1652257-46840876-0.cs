    foreach (string item in summaryList)
    {
        //kelola data
        if(item.Contains("Central"))
        {
            targetSummary = System.Math.Round(_context.Target.Where(x => x.Month == monthId && x.Region.Contains("Central") && x.Type == "SellThru").Select(y => y.Target1 ?? 0).Sum(), 2);
        }
    
        if (item.Contains("East"))
        {
            targetSummary = System.Math.Round(_context.Target.Where(x => x.Month == monthId && x.Region.Contains("East") && x.Type == "SellThru").Select(y => y.Target1 ?? 0).Sum(), 2);
        }
    
        if (item.Contains("West"))
        {
            targetSummary = System.Math.Round(_context.Target.Where(x => x.Month == monthId && x.Region.Contains("West") && x.Type == "SellThru").Select(y => y.Target1 ?? 0).Sum(), 2);
        }
        else
        {
            targetSummary = System.Math.Round(_context.Target.Where(x => x.Month == monthId && x.Region.Contains(item) && x.Type == "SellThru").Select(y => y.Target1 ?? 0).Sum(), 2);
        }
