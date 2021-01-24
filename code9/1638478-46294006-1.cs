    var connectionString = "<your connection string>";
    var topicName = "<your topic name>";
    
    var client = SubscriptionClient.CreateFromConnectionString(connectionString, topicName, "<your subscription name>");
    client.OnMessage(message =>
    {
      Console.WriteLine(String.Format("Message body: {0}", message.GetBody<String>()));
      Console.WriteLine(String.Format("Message id: {0}", message.MessageId));
    });
