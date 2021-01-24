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
        //POCO is created with actual values 
        TOptions options = configuration.Get<TOptions>();
        
        services.AddSingleton(options);
        return services;
    }
