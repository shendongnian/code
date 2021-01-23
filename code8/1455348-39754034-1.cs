    public void ConfigureServices(IServiceCollection services)
    {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddOptions();
            services.AddMvc();
            services.AddSingleton<Tester, Tester>();
            // Configure TestOptions using config 
            services.Configure<TestOptions>(Configuration);
            // Configure MyOptions using code
            services.Configure<TestOptions>(testOptions =>
            {
               // initialize them here, e.g. testOptions.Foo = "Bar"
            });
    }
