    public class CreatedEventHandler : MessageHandler<CreatedEvent>
    {
        public Task<IMessageResult> Handle(CreatedEvent message)
        {
            // ...
        }
    }
