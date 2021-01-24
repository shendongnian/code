    public static void ConfigureUnity(HttpConfiguration config)
    {
        var container = new UnityContainer();
        container.RegisterType<DbContext>(new HierarchicalLifetimeManager());
        container.RegisterType<ISupplierRepository, SupplierRepository>();
        container.RegisterType<IContactRepository, ContactRepository>();
        config.DependencyResolver = new UnityHierarchicalDependencyResolver(container);
    }
