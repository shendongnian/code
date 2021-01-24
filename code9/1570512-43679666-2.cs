    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingletonFromFile<MyOptions>(Configuration.GetSection("MySection"));
    }
    //...
    public static IServiceCollection AddSingletonFromFile<TOptions>(
        this IServiceCollection services,
        IConfiguration configuration)
        where TOptions : class, new()
    {
        var options = new TOptions(); //this is POCO instance
        configuration.Bind(options);
        services.AddSingleton(options);
        return services;
    }
