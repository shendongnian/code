    public interface IMessageHandler
    {
          Task<IMessageResult> Handle(IMessage message);
    }
    public interface IMessageHandler<TMessage> : IMessageHandler
           where TMessage : IMessage
    {
           Task<IMessageResult> Handle(TMessage message);
    }
    public class CreatedEventHandler : IMessageHandler<CreatedEvent>
    {
        public Task<IMessageResult> Handle(CreatedEvent message)
        {
            // ...
        }
       
        // I would implement the non-generic Handle(IMessage) explicitly
        // to hide it from the public surface. You'll access it when successfully
        // casting a reference to IMessageHandler
        Task<IMessageResult> IMessageHandler.Handle(IMessage message) 
        {
             return Handle((CreatedEvent)message);
        }
    }
