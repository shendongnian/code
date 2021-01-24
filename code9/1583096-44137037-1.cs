    public class EventHandlerFactory : IEventHandlerFactory
    {
        private readonly Dictionary<Type, Type> _eventHandlers = new Dictionary<Type, Type>();
        public EventHandlerFactory()
        {
            //add a mapping between the type, and the handler
            //note - this could be done with reflection to automate this
            _eventHandlers.Add(typeof(SomeEvent), typeof(SomeEventHandler));
        }
        public IEventHandler<T> Create<T>(T @event) where T : IEvent
        {
            var handler = _eventHandlers[typeof(T)];
            if (handler != null)
            {
                //now use Activator.CreateInstance to instantiate the type
                return (IEventHandler<T>)Activator.CreateInstance(handler);
            }
            throw new Exception("Handler not found");
        }
    }
