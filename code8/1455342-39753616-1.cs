    public void ConfigureServices(IServiceCollection services) {
        // Add framework services.
        services.AddApplicationInsightsTelemetry(Configuration);
        services.AddOptions();
        services.AddMvc();
        services.AddSingleton<ITester, Tester>();
        services.AddSingleton<IConfigureOptions<TestOptions>, TestConfigurator>();
    }
