    while (true)
    {
        // Each SimpleSubscriber instance must only be used once.
        var simpleSubscriber = await SimpleSubscriber.CreateAsync(subscriptionName);
        try
        {
            await simpleSubscriber.StartAsync((msg, cancellationToken) =>
            {
                // Process the message here.
                return Task.FromResult(SimpleSubscriber.Reply.Ack);
            });
        }
        catch (Exception e)
        {
            // Handle the unrecoverable error somehow...
        }
    }
