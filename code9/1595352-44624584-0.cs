    SubscriptionClient Client = SubscriptionClient.CreateFromConnectionString(connectionString, "topic name", "subscription name");
    
    // Configure the callback options.
    OnMessageOptions options = new OnMessageOptions();
    options.AutoComplete = false;
    options.AutoRenewTimeout = TimeSpan.FromSeconds(60);
    
    Client.OnMessage((message) =>
    {
        try
        {
            //process the message here, I used following code to simulation a long time spent job
            for (int i = 0; i < 30; i++)
            {
                Thread.Sleep(3000);
            }
            // Remove message from subscription.
            message.Complete();
        }
        catch (Exception ex)
        {
            // Indicates a problem, unlock message in subscription.
            message.Abandon();
        }
    }, options);
