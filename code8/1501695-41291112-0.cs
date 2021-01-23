    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        ....
        var applicationLifetime = app.ApplicationServices.GetRequiredService<IApplicationLifetime>();
        applicationLifetime.ApplicationStopping.Register(OnShutdown);
        ....
    }
    private void OnShutdown()
    {
        Console.WriteLine("Goodbye!");
    }
