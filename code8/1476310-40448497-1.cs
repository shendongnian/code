    public abstract class MessageHandler<TMessage> : IMessageHandler<TMessage>, IMessageHandler<IMessage>
           where TMessage : IMessage
    {
            public abstract Task<IMessageResult> Handle(TMessage message);
                   
            Task<IMessageResult> IMessageHandler<IMessage>.Handle(IMessage message) 
            {
                 return Handle((TMessage)message);
            }
    }
