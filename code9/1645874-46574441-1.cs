    container.RegisterType<IGenericRepository<Cat>, GenericRepository<Cat>>(
        new HierarchicalLifetimeManager());
    container.RegisterType<IGenericRepository<Dog>, GenericRepository<Dog>>(
        new HierarchicalLifetimeManager());
    // Separate 'scoped' registration for AnimalEntities.
    container.Register<AnimalEntities>(
        new HierarchicalLifetimeManager()
        new InjectionFactory(c => new AnimalEntities()));
