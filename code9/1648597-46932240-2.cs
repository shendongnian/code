    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        loggerFactory.AddConsole(); // Configuration.GetSection("Logging"));
        loggerFactory.AddDebug();
        app.UseAuthentication();// The missing line
    
        app.UseStaticFiles();
    
        app.UseMvc();
    }
