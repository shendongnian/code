    public class EventContainer : IEventDispatcher
    {
        private readonly IServiceCollection _serviceCollection;
        public EventContainer(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }
        
        public void Dispatch<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent
        {
            var services = _serviceCollection.BuildServiceProvider().GetServices<IDomainHandler<TEvent>>();
            foreach (var handler in services)
            {
                handler.Handle(eventToDispatch);
            }
        }
    }
