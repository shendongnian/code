    container.RegisterType<IUserPermissionService, UserPermissionService>(
        GetLifetime(), 
        new InjectionConstructor(
            new ResolvedParameter<IReadOnlyRepository<Customer>>("ReadOnlyAuth"),
            new ResolvedParameter<IReadOnlyRepository<VisitPlan>>("ReadOnlyAuth"),
            new ResolvedParameter<IReadOnlyRepository<UserBranch>>("ReadOnlyAuth"),
            new ResolvedParameter<IReadOnlyRepository<UserRoute>>("ReadOnlyAuth"),
            new ResolvedParameter<IReadOnlyRepository<UserDriverNumber>>("ReadOnlyAuth"),
            new ResolvedParameter<IReadOnlyRepository<UserActivity>>("ReadOnlyAuth"),
            new ResolvedParameter<IReadOnlyRepository<UserRole>>("ReadOnlyAuth")
        ));
