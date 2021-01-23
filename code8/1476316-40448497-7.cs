    public abstract class MessageHandler<TMessage> : IMessageHandler<TMessage>
           where TMessage : IMessage
    {
            public abstract Task<IMessageResult> Handle(TMessage message);
                   
            // I would implement the non-generic Handle(IMessage) explicitly
            // to hide it from the public surface. You'll access it when successfully
            // casting a reference to IMessageHandler
            Task<IMessageResult> IMessageHandler.Handle(IMessage message) 
            {
                 return Handle((TMessage)message);
            }
    }
