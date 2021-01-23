    /// <summary>
    /// Configures Autofac DI/IoC
    /// </summary>
    /// <param name="app"></param>
    /// <param name="config"></param>
    private IContainer ConfigureInversionOfControl(IAppBuilder app, HttpConfiguration config)
    {
    
        // Create our container
        var builder = new ContainerBuilder();
    
        // You can register controllers all at once using assembly scanning...
        builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
    
        // Register our module
        builder.RegisterModule(new AutofacModule());
        // [!!!] ** Register assemblies of the current domain **
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        builder.RegisterAssemblyModules(assemblies);
    
        // Build
        var container = builder.Build();
    
        // Lets Web API know it should locate services using the AutofacWebApiDependencyResolver
        config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
    
        // Return our container
        return container;
    }
