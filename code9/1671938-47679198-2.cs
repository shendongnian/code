    public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection services) where TService : class where TImplementation : class, TService
    {
      if (services == null)
        throw new ArgumentNullException(nameof (services));
      return services.AddTransient(typeof (TService), typeof (TImplementation));
    }
