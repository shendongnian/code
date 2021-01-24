    public static IServiceCollection AddTransient(this IServiceCollection services, Type serviceType)
    {
      if (services == null)
        throw new ArgumentNullException(nameof (services));
      if (serviceType == (Type) null)
        throw new ArgumentNullException(nameof (serviceType));
      return services.AddTransient(serviceType, serviceType);
    }
