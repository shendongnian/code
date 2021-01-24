    public void ConfigureServices(IServiceCollection services)
    {
        // Load the settings directly at startup.
        var settings = Configuration.GetSection("Root:MySettings").Get<MySettings>();
        // Verify mailSettings here (if required)
        service.AddHangfire(
            // use settings variable here
        );
        // If the settings needs to be injected, do this:
        container.AddSingleton(settings);
    }
