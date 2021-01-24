    public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
        ILoggerFactory loggerFactory)
    {
        loggerFactory.AddConsole(Configuration.GetSection("Logging"));
        loggerFactory.AddDebug(); // ⇦ you're not passing the LogLevel!
        app.UseMvc();
    }
