    public void ConfigureServices(IServiceCollection services)
    {
	    ...
        services.AddSingleton<IMyService, MyService>();
		...
			
         services.AddMvc();
    }
