    var subscriber = connectionMultiplexer.GetSubscriber();
    // Publish to ensure all handlers share the same subscription
    var publishedEvents = subscriber.WhenMessageReceived("my_channel")
        .Select(msg => ParseEventFromMessage(msg))
        .Publish();
    
    // Start the subscriptions before .Connect()
    var handleTasks = eventHandlers.Select(h => h.HandleEventsAsync(publishedEvents)).ToArray();
    
    // Connect to start the subscription to Redis
    using(publishedEvents.Connect())
    {
        // Wait for all handlers
        await Task.WhenAll(handleTasks);
    }
