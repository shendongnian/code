    public static void ConfigureUnity(HttpConfiguration config)
    {
        var context = new DbContext();
        var container = new UnityContainer();
        container.RegisterType<ISupplierRepository, SupplierRepository>(new InjectionConstructor(context));
        container.RegisterType<IContactRepository, ContactRepository>(new InjectionConstructor(context));
        config.DependencyResolver = new UnityResolver(container);
    }
