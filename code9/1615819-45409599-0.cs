    var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
    
    for (int i = 0; i < 2; i++)
    {
        if (i == 0)
        {
            client.SendAsync(new BrokeredMessage("testmes1") { MessageId = "test1", ScheduledEnqueueTimeUtc = DateTime.UtcNow.AddSeconds(60) }).Wait();
        }
        else
        {
            client.SendAsync(new BrokeredMessage("testmes2") { MessageId = "test1" }).Wait();
        }
    
    } 
