    public static IServiceCollection AddLogging(this IServiceCollection services, Action<ILoggingBuilder> configure)
    {
        // …
        services.TryAdd(ServiceDescriptor.Singleton<ILoggerFactory, LoggerFactory>());
        services.TryAdd(ServiceDescriptor.Singleton(typeof(ILogger<>), typeof(Logger<>)));
        // …
    }
