    SplatResolver = Locator.CurrentMutable;
    var customResolver = new FuncDependencyResolver((service, contract) =>
    {
        IEnumerable<Object> services = null;
        services = SplatResolver.GetServices(service, contract);
        if (services == null || services.Count() == 0)
        {
            var svc = containerSI.GetInstance(service);
            if (svc != null)
            {
                services = new Object[] { svc };
            }
        }
        if (services == null || services.Count() == 0)
        {
            services = containerSI.GetAllInstances(service); // only applies services registered with .RegisterCollection()
        }
        return services;
    }, (factory, service, contract) =>
    {
        SplatResolver.Register(factory, service, contract);
        try
        {
            containerSI.Register(service, factory);
        }
        catch (Exception exc)
        {
            // certain services are registered multiple times by RxUI.  For now, ignore them.
            //ICreatesObservableForProperty
            Console.WriteLine(exc.ToString());
        }
    });
    Locator.Current = customResolver;
