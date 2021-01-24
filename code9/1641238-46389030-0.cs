    foreach (var entityTypeInfo in _dbContextEntityFinder.GetEntityTypeInfos(dbContextType))
    {
        // ...
        iocManager.IocContainer.Register(
            Component
                .For(genericRepositoryType)
                .ImplementedBy(implType)
                .Named(Guid.NewGuid().ToString("N"))
                .LifestyleTransient()
    }
