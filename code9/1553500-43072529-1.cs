    public static void Configure(IAppBuilder app)
    {
    	GlobalConfiguration.Configure(Register);
    }
    
    private static void Register(HttpConfiguration config)
    {
    	ConfigureHttpRoutes(config);
    
    	ConfigureFormatters(config);
    
    	//etc...
    }
