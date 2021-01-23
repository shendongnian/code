    ILogger _logger = GetLogger();  //Might be any type of Logger
    SqlLogger sqlLogger = _logger as SqlLogger;  //Try to get class-specific interface
    if (sqlLogger != null)  //Logger is in fact a SqlLogger
    {
        sqlLogger.SetConnectionString(AppConfig.LoggerConnectionString); //Call method not in interface
    }
    _logger.Log("Logger started.");  //Using class-agnostic interface to actually log data
