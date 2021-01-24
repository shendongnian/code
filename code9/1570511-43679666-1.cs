    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransientFromService<OptionsReader, MyOptions>(x => x.GetMyOptions());
    }
    public static void AddTransientFromService<TService, TOptions>(
        this IServiceCollection services,
        Func<TService, TOptions> getOptions)
        where TOptions : class
        where TService : class
    {
        services.AddTransient(provider => getOptions(provider.GetService<TService>()));
    }
