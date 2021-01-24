    private MvxSubscriptionToken _messageToken;              
 
    _messageToken = _mvxMessenger.Subscribe<ValuesChangedMessage>(async message =>
            {
                // use message.Valuea etc ..
            });
