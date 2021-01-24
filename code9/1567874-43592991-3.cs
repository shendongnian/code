    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<DataContext>( <!-- your code --> );
        services.AddMvc();
        services.AddScoped<LocationLookupService>();
    }
