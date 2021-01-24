    container.RegisterSingleton<IRepoProvider>(new RepoProvider(
        oracle: new Dictionary<Type, InstanceProducer>
        {
            { typeof(ICarRepository), Lifestyle.Transient.CreateProducer<ICarRepository, OraCarRepository>(container) },
            { typeof(ITruckRepository), Lifestyle.Transient.CreateProducer<ITruckRepository, OraTruckRepository>(container) },
        },
        sql: new Dictionary<Type, InstanceProducer>
        {
            { typeof(ICarRepository), Lifestyle.Transient.CreateProducer<ICarRepository, SqlCarRepository>(container) },
            { typeof(ITruckRepository), Lifestyle.Transient.CreateProducer<ITruckRepository, SqlTruckRepository>(container) },
        });
