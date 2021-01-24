    client.OnMessage(message =>
    {
        Console.WriteLine(String.Format("Message body: {0}", message.GetBody<String>()));
        Console.WriteLine(String.Format("Message id: {0}", message.MessageId));
    });
