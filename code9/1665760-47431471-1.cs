    public class Dispatcher
    {
        private readonly Dictionary<int, IHandler> handlers;
        public Dispatcher(IEnumerable<IHandler> handlers)
        {
            this.handlers = handlers.ToDictionary(h => h.RequiredMessageType, h => h);
        }
        public void Dispatch(IMessage message)
        {
            handlers[message.MessageType].Handle(message);
        }
    }
