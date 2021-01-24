    public void ConfigureServices(IServiceCollection services)
    {
    
    	services
    		.AddMvc(options =>
    			{
    				options.Filters.Add(typeof(MyLoggingFilter), -2);
    				options.Filters.Add(typeof(MyAuthFilter), -1);
    			});
    }
