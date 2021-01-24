    protected override IMvxLogProvider CreateLogProvider()
    {
    	Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.LiterateConsole()
                    .WriteTo.AndroidLog()
                    .CreateLogger();
    	return base.CreateLogProvider();
    }
