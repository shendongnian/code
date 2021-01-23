    public class CompositeHandler : IHandler
    {
        private readonly IHandler[] handlers;
        public CompositeHandler(params IHandler[] handlers)
        {
            this.handlers = handlers;
        }
        public T Process<T>(int process)
        {
            var handler = handlers.FirstOrDefault(h => h.CanProcess<T>());
            if(handler == null)
                throw new Exception(
                    "Contract violated. I cannot handle type " + typeof(T).Name);
            return handler.Process<T>(process);
        }
        public bool CanProcess<T>()
        {
            return handlers.Any(h => h.CanProcess<T>());
        }
    }
