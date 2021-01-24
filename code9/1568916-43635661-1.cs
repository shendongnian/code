    public void ConfigureServices(IServiceCollection services)
    {    
        services.AddTransient<OptionsReader>();
        services.AddSingletonFromService<OptionsReader, MyOptions>(x => x.GetMyOptions());
    }
    
