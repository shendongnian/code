    public static IServiceCollection AddMyLibrary(this IServiceCollection services)
    {
        services.TryAddTransient<IService, Service>();
        services.TryAddTransient<IOtherService, OtherService>();
    }
