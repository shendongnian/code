    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplicationInsightsTelemetry(Configuration); // here
        var builder = services.AddMvc();
    }
