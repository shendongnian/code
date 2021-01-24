    private static IEnumerable<T> TryResolveCollection<T>(IComponentContext context)
    {
        bool RegistrationProvidesService(IComponentRegistration registration) =>
            registration.Services.OfType<IServiceWithType>().Any(it => it.ServiceType.Name == typeof(T).Name);
        var registrations = context.ComponentRegistry.Registrations.Where(RegistrationProvidesService);
        var resolvedServices = new HashSet<Type>();
        foreach (var registration in registrations)
        {
            T service;
            try
            {
                service = (T)context.ResolveComponent(registration, Enumerable.Empty<Parameter>());
            }
            catch (DependencyResolutionException)
            {
                continue;
            }
            if (resolvedServices.Add(service.GetType()))
            {
                yield return service;
            }
        }
    }
