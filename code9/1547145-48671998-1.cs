    deviceClientFactory = IotHubClient.PreparePoolFactory(
        "IotHubConnectionString",
        400,
        TimeSpan.FromMinutes(3),
        iotHubClientSettings,
        PooledByteBufferAllocator.Default,
        new ConfigurableMessageAddressConverter("TopicNameConversion"));
		
