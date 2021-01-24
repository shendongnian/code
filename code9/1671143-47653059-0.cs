    Conversation.UpdateContainer(
               builder =>
               {
                   builder.Register(c => store)
                             .Keyed<IBotDataStore<BotData>>(AzureModule.Key_DataStore)
                             .AsSelf()
                             .SingleInstance();
    
                   builder.Register(c => new CachingBotDataStore(store,
                              CachingBotDataStoreConsistencyPolicy
                              .ETagBasedConsistency))
                              .As<IBotDataStore<BotData>>()
                              .AsSelf()
                              .InstancePerLifetimeScope();
    
    
               });
