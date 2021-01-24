    var logFactory = NLogBuilder.ConfigureNLog("NLog.config");
    logFactory.Configuration.KeepVariablesOnReload = true;
    logFactory.Configuration.Variables["connectionString"] = Configuration.GetConnectionString("myDb");
    logFactory.Configuration.Reload();
    var logger = logFactory.GetCurrentClassLogger();
    logger.Info("Hello World");
