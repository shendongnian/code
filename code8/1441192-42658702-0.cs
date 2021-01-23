    var namespaceMngr = NamespaceManager.CreateFromConnectionString(namespaceConnString);
    MessagingFactorySettings mfs = new MessagingFactorySettings();
    mfs.TokenProvider = namespaceMngr.Settings.TokenProvider;
    mfs.NetMessagingTransportSettings.BatchFlushInterval = TimeSpan.FromSeconds(timeToFlush);
    MessagingFactory mf = MessagingFactory.Create(namespaceMngr.Address, mfs);
