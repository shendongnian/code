    public static Serilog.ILogger BuildLogger(IConfiguration config, SerilogSubLoggerConfigurations slcs)
    {
    	var lc = new LoggerConfiguration();
    	lc.ReadFrom.Configuration(config);
    
    	foreach (var cfg in slcs.SubLoggers)
    	{
    		lc.WriteTo.Logger(logger => logger.Filter
    			.ByIncludingOnly(lvl => lvl.Level == cfg.Level).WriteTo
    			.RollingFile(cfg.PathFormat));
    	}
    
    	//	Apply any additional changes to lc configuration here
    
    	//	Finally build a logger
    	return lc.CreateLogger();
    }
    static void Main(string[] args)
    {
    	//	...
    	var logger = BuildLogger(configuration, subLoggerConfigurations);
    
        //  No any changes could be made to logging configuration at this point.
        //  Just log what you need.
    
    	logger.Information("Test info message");
    }
