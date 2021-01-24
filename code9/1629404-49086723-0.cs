    public static IServiceProvider ConfigureServices(IServiceCollection serviceCollection)
    {
    	//ILoggerFactory loggerFactory = new LoggerFactory()
    	//	.AddConsole()
    	//	.AddDebug();
    
    	serviceCollection
    		.AddLogging(opt =>
    		{
    			opt.AddConsole();
    			opt.AddDebug();
    		})
    		.AddTransient<IFooService, FooService>();
        /*... rest of config */
	
        var serviceProvider = serviceCollection.BuildServiceProvider();
    	return serviceProvider;
}
