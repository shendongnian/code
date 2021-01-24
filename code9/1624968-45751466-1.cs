    public static IMyServiceCollection CreateServiceCollection(this IServiceCollection services, IConfiguration config)
    {
        return new MyServiceCollection 
        { 
            Services = services,
            Configuration = config
        };
    }
