    class Subscription
    {
        public object Instance { get; set; }
        public Action<object, object> Handler;
    }
    public class MessageBus
    {
        #region Singleton
        private static readonly MessageBus _instance = new MessageBus();
        public static MessageBus Default => _instance;
        private MessageBus()
        {
        }
        #endregion
        private readonly Dictionary<string, List<Action<object, object>>> _hadlersMap 
            = new Dictionary<string, List<Action<object, object>>>();
        public void Call(string name, object sender, object data)
        {
            List<Action<object, object>> handlers;
            if(!_hadlersMap.TryGetValue(name.ToUpper(), out handlers))
                return;
            foreach (var handler in handlers)
            {
                 handler?.Invoke(sender,data);
            }
        }
        public void Subscribe(string name, Action<object, object> handler)
        {
            name = name.ToUpper();
            List<Action<object, object>> handlers;
            if (!_hadlersMap.TryGetValue(name, out handlers))
            {
                handlers = new List<Action<object, object>>{ handler }; 
                _hadlersMap.Add(name, handlers);
            }
            else
            {
                handlers.Add(handler);
            }
        }
    }
