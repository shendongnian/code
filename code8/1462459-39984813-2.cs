    protected void Application_Start()
    {
        WindsorContainer container = new WindsorContainer();
        container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
        container.Install(FromAssembly.This());
    }
