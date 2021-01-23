    ILogger GetLogger()  //Factory method.  Uses config to determine what sort of ILogger to return.
    {
        if (AppConfig.UseFlatFileLogger) return new FlatFileLogger();
        if (AppConfig.UseSqlLogger )
        {
            SqlLogger sqlLogger = new SqlLogger();
            sqlLogger.SetConnectionString(GetLoggerConnectionString()); //Call method not in interface
            return sqlLogger;
        }
        throw new ConfigurationException("Logger type not supported.");
    {
    //Main program.  Notice 100% of this code is class-agnostic.
    ILogger _logger = GetLogger();  
    _logger.Log("Logger started."); 
