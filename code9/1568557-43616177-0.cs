    public override void Subscribe(Action<IMessage> onMessageReceived)
    {
        try
        {
            MessageListener messageListener = new MessageListener(onMessageReceived);
            _consumer.MessageListener = messageListener;
            _connection.Start();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
