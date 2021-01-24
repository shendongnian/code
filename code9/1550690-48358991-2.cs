    public class SimpleMediator : IMediator
    {
        private readonly IServiceProvider provider;
        private readonly IEventRegistrator registrator;
        public SimpleMediator(IEventRegistrator registrator, IServiceProvider provider)
        {
            this.registrator = registrator;
            this.provider = provider;
        }
        public async Task Dispatch<T>(T target)
            where T : IEvent
        {
            var handlers = registrator.GetHandlers<T>();
            if (handlers == null) return;
            foreach (Type item in handlers)
            {
                var instance = (IEventHandler<T>)provider.GetService(item);
                if (instance == null) throw new NullReferenceException($"No type {item.ToString()} has been registred on the service collections. Add this type to the service collections.");
                await instance.HandleAsync(target);
            }
        }
    }
