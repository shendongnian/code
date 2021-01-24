    public interface IEventHandler
    {
        void Handle(IEvent @event);
    }
    public interface IEventHandler<TEvent> : IEventHandler where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }
