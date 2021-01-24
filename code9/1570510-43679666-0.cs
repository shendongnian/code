    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingletonFromFile<MyOptions>(Configuration.GetSection("MySection"));
    }
    public static IServiceCollection AddSingletonFromFile<TOptions>(
        this IServiceCollection services,
        IConfiguration configuration)
        where TOptions : class, new()
    {
        var config = new TOptions();
        configuration.Bind(config);
        services.AddSingleton(config);
        return services;
    }
