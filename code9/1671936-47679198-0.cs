    public static IServiceCollection AddTransient<TService>(this IServiceCollection services) where TService : class
    {
      if (services == null)
        throw new ArgumentNullException(nameof (services));
      return services.AddTransient(typeof (TService));
    }
