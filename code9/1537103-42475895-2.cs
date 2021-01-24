    public void ConfigureServices(IServiceCollection services)
    {
    	//services.Configure<MyConfiguration>(Configuration.GetSection("myConfiguration"));
    	services.AddSingleton(Configuration.GetSection("myConfiguration").Get<MyConfiguration>());
    }
