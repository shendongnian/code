    IUnityContainer container = new UnityContainer();
    container.RegisterType<ILogger, MyLogger>("Logger1");
    container.RegisterType<ILogger, MyLogger>("Logger2");
    container.RegisterType<ILogger, MyLogger>("Logger3");
    // Resolve list of all loggers
    var loggers = container.Resolve<ILogger[]>();
    // Remove Policies for all ILoggers using ClearAllPolicies
    foreach (var registration in container.Registrations
                                          .Where(r => r.RegisteredType == typeof(ILogger)))
    {
        container.RegisterType(
           registration.RegisteredType,
           registration.MappedToType, 
           registration.Name, 
           new ClearAllPolicies());
    }
    // Ensure that when we try to resolve an ILogger or list of ILogger's that
    // an exception is thrown
    Assert.Throws<ResolutionFailedException>(() => container.Resolve<ILogger>("Logger1"));
    Assert.Throws<ResolutionFailedException>(() => container.Resolve<ILogger>("Logger2"));
    Assert.Throws<ResolutionFailedException>(() => container.Resolve<ILogger>("Logger3"));
    Assert.Throws<ResolutionFailedException>(() => container.Resolve<ILogger[]>());
