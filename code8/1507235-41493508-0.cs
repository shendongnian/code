    public void ConfigureServices(IServiceCollection services)
    {
    	services.AddMvc();
     
    	services.AddDistributedRedisCache(option =>
    	{
    		option.Configuration = "127.0.0.1";
    		option.InstanceName = "master";
    	});
    }
