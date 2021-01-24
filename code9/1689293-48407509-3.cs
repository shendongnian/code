    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider sp)
    {
        app.UseDefaultFiles();
        app.UseStaticFiles();
        app.UseSignalR(routes =>
        {
            routes.MapHub<MyHub>(MyHub.HubName);
        });
        app.UseMvc();
        // This is just an example line of how you can get the hub with context:
        var myHub = sp.GetService<HubMethods<MyHub>>();
    }
