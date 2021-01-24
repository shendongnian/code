    public class EventRegistrator : IEventRegistrator
    {
        private readonly IDictionary<Type, IList<Type>> dictionary = new Dictionary<Type, IList<Type>>();
        public IEventRegistrator Add<Event, Handler>()
            where Event : IEvent
            where Handler : IEventHandler<Event>
        {
            var eventType = typeof(Event);
            var handlerType = typeof(Handler);
            if (!dictionary.ContainsKey(eventType))
            {
                dictionary[eventType] = new List<Type>();
            }
            dictionary[eventType].Add(handlerType);
            return this;
        }
        public IEnumerable<Type> GetHandlers<Event>()
            where Event : IEvent
        {
            if (dictionary.TryGetValue(typeof(Event), out IList<Type> handlers))
            {
                return handlers;
            }
            return new List<Type>();
        }
        public IEnumerable<Type> GetHandlers()
        {
            foreach (var item in dictionary)
            {
                foreach (var handler in item.Value)
                {
                    yield return handler;
                }
            }
        }
    }
