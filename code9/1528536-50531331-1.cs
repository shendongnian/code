    public void Configure(
    	IApplicationBuilder App,
    	IHostingEnvironment Env,
    	ILoggerFactory LoggerFactory,
    	IServiceProvider ServiceProvider
    )
    {
        /* trimmed */
	    CreateRoles(ServiceProvider).Wait();
    }
