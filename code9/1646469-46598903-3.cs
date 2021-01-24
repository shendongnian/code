    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
                ...
    
                // Have to be careful with static properties, they persist throughout the life time
                // of the application.  
                UtilsProvider.HostingEnvironment = env;
            }
