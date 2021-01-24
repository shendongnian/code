    private event EventHandler<MessageEventArgs> _onMessageReceived;
    event EventHandler<MessageEventArgs> MessageBroker.OnMessageReceived 
    { 
        add 
        { 
            _onMessageRecieved += value;
        }
        remove 
        { 
            _onMessageRecieved -= value; 
        }
    }
