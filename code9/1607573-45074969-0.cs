    public static void processmessage()
    {
        string connectionString = "{connectionstring here}";
    
        var queueName = "{queue name}";
    
        var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
        var options = new OnMessageOptions();
        options.AutoComplete = false;
    
        try
        {
            client.OnMessage(message =>
            {
                HandleTransaction(message);
            }, options);
        }
        catch (Exception)
        {
    
        }
    }
    
    private static void HandleTransaction(BrokeredMessage message)
    {
        Console.WriteLine(String.Format("Message body: {0}", message.GetBody<String>()));
    }
