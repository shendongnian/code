    public void ConfigureServices(IServiceCollection services)
        var provider = services.BuildServiceProvider();
        JobManager.Initialize(new LoadersRegistry(
            provider.GetRequiredService<DataContext>()
        ));
        
        services.AddMvc();
    }
