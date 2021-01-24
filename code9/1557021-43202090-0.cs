    public static IServiceCollection AddSession(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }
        services.AddTransient<ISessionStore, DistributedSessionStore>();
        services.AddDataProtection();
        return services;
    }
