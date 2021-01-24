    var builder = new ContainerBuilder();
    builder
        .Register(c => new CachingBotDataStore(c.Resolve<ConnectorStore>(), CachingBotDataStoreConsistencyPolicy.LastWriteWins))
        .As<IBotDataStore<BotData>>()
        .AsSelf()
        .InstancePerLifetimeScope();
    builder.Update(Conversation.Container);
