    var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
    
    var options = new OnMessageOptions();
    options.AutoComplete = false;
    
    client.OnMessage(mes =>
    {
        Console.WriteLine(mes.GetBody<string>());
    }, options);
