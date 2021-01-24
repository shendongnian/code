    container.RegisterType<IGenericRepository<Cat>, GenericRepository<Cat>>(
        new HierarchicalLifetimeManager(), 
        new InjectionConstructor(new AnimalEntities()));
    container.RegisterType<IGenericRepository<Dog>, GenericRepository<Dog>>(
        new HierarchicalLifetimeManager(), 
        new InjectionConstructor(new AnimalEntities()));
