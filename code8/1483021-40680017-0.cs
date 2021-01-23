    var options = EventProcessorOptions.DefaultOptions;
    options.MaxBatchSize = 50;
    var eventHubConfig = new EventHubConfiguration(options);
    string eventHubName = "MyHubName";
    eventHubConfig.AddSender(eventHubName, "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=SendRule;SharedAccessKey=xxxxxxxx");
    eventHubConfig.AddReceiver(eventHubName, "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=ReceiveRule;SharedAccessKey=yyyyyyy");
    config.UseEventHub(eventHubConfig);
    JobHost host = new JobHost(config);
