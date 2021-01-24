    public interface IEventHandler
    {
    }
    public interface IEventHandler<in T> : IEventHandler where T : IEvent
    {
        void Execute(T @event);
    }
    public class EventHandlerFactory
    {
        private static readonly Dictionary<Type, Func<IEventHandler>> _eventHandlers = new Dictionary<Type, Func<IEventHandler>>
        {
            { typeof(SomeEvent), () => new SomeEventHandler() }
        };
        public IEventHandler<T> Create<T>(T @event) where T : IEvent
        {
            Func<IEventHandler> handler;
            if (_eventHandlers.TryGetValue(typeof(T), out handler))
            {
                return (IEventHandler<T>)handler();
            }
            throw new Exception("Handler not found");
        }
    }
