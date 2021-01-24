    private static void EnsureInterfaceInterceptionApplies(IComponentRegistration componentRegistration)
    {
        if (componentRegistration.Services
            .OfType<IServiceWithType>()
            .Select(s => new Tuple<Type, TypeInfo>(s.ServiceType, s.ServiceType.GetTypeInfo()))
            .Any(s => !s.Item2.IsInterface || !ProxyUtil.IsAccessible(s.Item1)))
        {
            throw new InvalidOperationException(
                string.Format(
                    CultureInfo.CurrentCulture,
                    RegistrationExtensionsResources.InterfaceProxyingOnlySupportsInterfaceServices,
                    componentRegistration));
        }
    }
