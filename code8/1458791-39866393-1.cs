    public void ConfigureServices(IServiceCollection services) {
        services.AddApplicationInsightsTelemetry(Configuration);
        services.AddScoped<AppDbContext>();
        services.AddScoped<IBuyRepository, BuyRepository>();
        services.AddMvc();
        // How to add dependencies here
    }
