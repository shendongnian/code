    Log.Logger = new LoggerConfiguration().ReadFrom.AppSettings().WriteTo.AzureDocumentDB(endpoint, authorizationKey,timeToLive: ttl).CreateLogger();
    // Used to debug serilog itself and confirm it is writing entries to document db
    Serilog.Debugging.SelfLog.Enable(Console.Out);
    var errorOrInformation = new Dictionary<string, string>();
        errorOrInformation.Add(Constants.LoggingProperties.PartitionKey, logMetadata.PartitionKey);
        errorOrInformation.Add(Constants.LoggingProperties.RowKey, logMetadata.RowKey);
    //Add as many items as you want
    Log.Verbose("Log Information Message {Information}", errorOrInformation);
    // Also good idea to force flush of log entries before the app ends
    Log.CloseAndFlush();
