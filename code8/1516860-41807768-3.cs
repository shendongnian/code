    private static void InitializeContainer(Container container)
    {
        container.Register<IDataContextAsync, AppContext>(Lifestyle.Scoped);
        container.Register<IUnitOfWorkAsync, UnitOfWork>(Lifestyle.Scoped);
        container.Register<IRepositoryAsync<Setting>, Repository<Setting>>(Lifestyle.Scoped);
        container.Register<ISettingService, SettingService>(Lifestyle.Scoped);
        container.Register(typeof(ISettingProvider<>), typeof(SettingProvider<>));
        //container.Options.SettingRegistration();
    }
