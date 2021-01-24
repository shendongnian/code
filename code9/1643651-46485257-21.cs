    Configuration.ReplaceService<IRepository<Test, int>>(() =>
    {
        IocManager.IocContainer.Register(
            Component.For<IRepository<Test, int>, ITestRepository, TestRepository>()
                .ImplementedBy<TestRepository>()
                .LifestyleTransient()
        );
    });
