    var messages = new List<IMessage>
    {
        new ClassicMessage(),
        new MessageWithCustomContent()
    };
    foreach (var message in messages)
    {
        message.GetContent();
    }
