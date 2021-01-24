        public interface IMediator
    {
        Task Dispatch<T>(T target)
            where T : IEvent;
    }
    public interface IEventRegistrator
    {
        /// <summary>
        /// Register a handler to the event. Multiple handlers are supported
        /// </summary>
        IEventRegistrator Add<Event, Handler>()
            where Event : IEvent
            where Handler : IEventHandler<Event>;
        /// <summary>
        /// Returns all handlers to a event
        /// </summary>
        IEnumerable<Type> GetHandlers<Event>() where Event : IEvent;
        /// <summary>
        /// Returns all handlers of all registered events.
        /// </summary>
        IEnumerable<Type> GetHandlers();
    }
