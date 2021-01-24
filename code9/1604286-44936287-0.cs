    public void ConfigureService(IServiceCollection services)
    {
        services.AddTransient<IRepo, Repo>();
        services.AddTransient<Lazy<IRepo>>(provider => new Lazy<IRepo>(() => provider.GetService<IRepo>()));
    }
