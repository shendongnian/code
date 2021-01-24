    public override void Subscribe(Action<IMessage> onMessageReceived)
    {
        MessageListener messageListener = new MessageListener(onMessageReceived);
        _consumer.MessageListener = messageListener;
        _connection.Start();
    }
