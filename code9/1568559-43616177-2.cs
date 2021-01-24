    public override void Subscribe<T>(Action<T> onMessageReceived)
    {
        MessageListener messageListener = new MessageListener((m) =>         
        {
            T result = (T) m.Body; // or some other casting
            onMessageReceived(result);
        });`
        _consumer.MessageListener = messageListener;
        _connection.Start();
    }
