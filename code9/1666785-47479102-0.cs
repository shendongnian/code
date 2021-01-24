    public static void RegisterTransient(this IServiceCollection services)
    {
        // Use services registered so far
        var serviceProvider = services.BuildServiceProvider();
        var config = serviceProvider.GetRequiredService<Configuration>();
        services.AddDbContext<InteractiveChoicesContext>(m => m.UseSqlServer(config.ConnectionString));
    }
