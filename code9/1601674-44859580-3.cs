    var services = new ServiceCollection();
    services.AddLogging();
    var provider = services.BuildServiceProvider();
    var factory = provider.GetService<ILoggerFactory>();
    factory.AddNLog();
    factory.ConfigureNLog("nlog.config");
    var logger = provider.GetService<ILogger<Program>>();
    logger.LogCritical("hello nlog");
    
