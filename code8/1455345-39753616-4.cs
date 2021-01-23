    public void ConfigureServices(IServiceCollection services) {
        
        services.AddApplicationInsightsTelemetry(Configuration);
        // Setup options with DI
        services.AddOptions();
        // Configure TestOptions using config by installing Microsoft.Extensions.Options.ConfigurationExtensions
        services.Configure<TestOptions>(Configuration);
        // Configure TestOptions using code
        services.Configure<TestOptions>(testOptions => {
            testOptions.SomeOption = "value1_from_action";
        });
        // Add framework services.
        services.AddMvc();
    
        // Add your services.
        services.AddSingleton<ITester, Tester>();
    }
