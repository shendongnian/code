    public void ConfigureServices(IServiceCollection services) {
        services.AddScoped<ServiceImplementation>();
        services.AddScoped<IService>(
            provider => provider.GetService<ServiceImplementation>()
        );
    }
