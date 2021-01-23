    public override void ItemAdded(SPItemEventProperties properties)
    {
        var connectionString = "<Your connection string>";
        var queueName = "<Your queue name>";
        var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
        var message = new BrokeredMessage("This is a test message!");
        client.Send(message);
       
        base.ItemAdded(properties);
    }
