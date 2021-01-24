    public class NoteCreatedEventHandler : IEventHandler<NoteCreatedEvent>
    {
        public void Handle(IEvent @event)
        {
            Handle((NoteCreatedEvent)@event);
        }
        public void Handle(NoteCreatedEvent @event)
        {
        }        
    }
