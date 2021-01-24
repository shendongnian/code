    var myClasses = AllClasses.FromAssembliesInBasePath().Where(t => t.Namespace.StartsWith("MyProject", StringComparison.OrdinalIgnoreCase));
    foreach (var type in myClasses)
    {
        var matchingInterfaceName = "I" + type.Name;
        var interfaceType = type.GetInterfaces().FirstOrDefault(i => string.Compare(i.Name, matchingInterfaceName, StringComparison.Ordinal) == 0);
        if (interfaceType != null)
        {
            container.RegisterType(interfaceType, type, new ContainerControlledLifetimeManager(),
                new InjectionMember[]
                {
                    new Interceptor<InterfaceInterceptor>(),
                    new InterceptionBehavior<LoggingInterceptionBehavior>()
                });
        }
    }
