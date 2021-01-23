            var serviceBusConnectionString = new ServiceBusConnectionStringBuilder(connection.ConnectionString);
            MessagingFactorySettings factorySettings = new MessagingFactorySettings();
            factorySettings.TransportType = serviceBusConnectionString.TransportType;
            //Use the  namespacemanager to create the token provider.
            var namespaceManager = NamespaceManager.CreateFromConnectionString(connection.ConnectionString);
            factorySettings.TokenProvider = namespaceManager.Settings.TokenProvider;
            factorySettings.NetMessagingTransportSettings.BatchFlushInterval = TimeSpan.FromMilliseconds(batchTimeInMs);
            MessagingFactory factory = MessagingFactory.Create(serviceBusConnectionString.Endpoints, factorySettings);
            return factory.CreateTopicClient(topicName);
