    foreach (var user in users.ToList())
    {
       var statisticsService = new Instance<IStatisticsService>();
    
       var statistic1 = GetStatistic(1); // this returns an object
       var statistic 2 = GetStatistic(2);
    
       statisticsService.Add(statistic1);
       statisticsService.Add(statistic2);
    
       statisticsService.Commit(); /* this is essentially a dbContext.SaveChanges(); */
    }
