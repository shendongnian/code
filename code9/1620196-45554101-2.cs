    container.RegisterType<IUserPermissionService, UserPermissionService>(
        GetLifetime(), 
        new InjectionFactory(c =>
        {
            new UserPermissionService(
                c.Resolve<IReadOnlyRepository<Customer>>("ReadOnlyAuth"),
                c.Resolve<IReadOnlyRepository<VisitPlan>>("ReadOnlyAuth"),
                c.Resolve<IReadOnlyRepository<UserBranch>>("ReadOnlyAuth"),
                c.Resolve<IReadOnlyRepository<UserRoute>>("ReadOnlyAuth"),
                c.Resolve<IReadOnlyRepository<UserDriverNumber>>("ReadOnlyAuth"),
                c.Resolve<IReadOnlyRepository<UserActivity>>("ReadOnlyAuth"),
                c.Resolve<IReadOnlyRepository<UserRole>>("ReadOnlyAuth")
        }));
