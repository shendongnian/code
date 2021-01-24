    var settings = new TransactionSettings(   
                   UseDTCOption.UseConfigurationSetting, 
                   System.Transactions.IsolationLevel.ReadCommitted, 
                   new TimeSpan(0, 2, 0));
    var queryStrategy = new QueryStrategy(QueryStrategy.Normal, settings);
    myPM.DefaultQueryStrategy = queryStrategy;
