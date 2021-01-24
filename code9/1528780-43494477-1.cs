    public void Configure(IApplicationBuilder app, 
                IHostingEnvironment env, 
                ILoggerFactory loggerFactory,
                IApplicationLifetime lifetime,
                IServiceProvider container)
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
    
                app.UseMvc();
    
                // the following 3 lines hook QuartzStartup into web host lifecycle
                var quartz = new QuartzStartup(container);
                lifetime.ApplicationStarted.Register(quartz.Start);
                lifetime.ApplicationStopping.Register(quartz.Stop);
            }
