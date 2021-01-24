    public void ConfigureService(IServiceCollection services)
    {
        services.AddTransient<IRepo, Repo>();
        services.Add(ServiceDescriptor.Transient(typeof(Lazy<>), typeof(Lazy<>)));
    }
