    public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            IServiceProvider serviceProvider)
        {
            ...
            
            // Configure hangfire to use the new JobActivator we defined.
            GlobalConfiguration.Configuration
                .UseActivator(new HangfireActivator(serviceProvider));
            // The rest of the hangfire config as usual.
            app.UseHangfireServer();
            app.UseHangfireDashboard();
        }  
