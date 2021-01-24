    public static IServiceCollection AddSingletonsByConvention(this IServiceCollection services, Assembly assembly, Func<Type, bool> interfacePredicate, Func<Type, bool> implementationPredicate)
    {
        var interfaces = assembly.ExportedTypes
            .Where(x => x.IsInterface && interfacePredicate(x))
            .ToList();
        var implementations = assembly.ExportedTypes
            .Where(x => !x.IsInterface && !x.IsAbstract && implementationPredicate(x))
            .ToList();
        foreach (var @interface in interfaces)
        {
            var implementation = implementations.FirstOrDefault(x => @interface.IsAssignableFrom(x));
            if (implementation == null) continue;
            services.AddSingleton(@interface, implementation);
        }
        return services;
    }
    
    public static IServiceCollection AddSingletonsByConvention(this IServiceCollection services, Assembly assembly, Func<Type, bool> predicate)
        => services.AddSingletonsByConvention(assembly, predicate, predicate);
