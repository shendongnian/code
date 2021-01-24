    var memorystore = new InMemoryDataStore();
        builder
             .RegisterType<InMemoryDataStore>()
             .Keyed<IBotDataStore<BotData>>(typeof(ConnectorStore));
     
        builder.Register(c => new CachingBotDataStore(memorystore, CachingBotDataStoreConsistencyPolicy.ETagBasedConsistency))
               .As<IBotDataStore<BotData>>()
               .AsSelf()
               .SingleInstance();
