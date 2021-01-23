    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(options =>
        {
            options.Filters.Add(typeof(SampleActionFilter)); // by type
            options.Filters.Add(new SampleGlobalActionFilter()); // an instance
        });
        services.AddScoped<AddHeaderFilterWithDi>();
    }
