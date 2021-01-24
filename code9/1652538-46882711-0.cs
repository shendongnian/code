    public class NinjectDomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IResolutionRoot resolutionRoot;
        public NinjectDomainEventDispatcher(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }
        public void Dispatch<T>(T domainEvent) where T : IDomainEvent
        {
            var handlers = this.resolutionRoot.GetAll<IDomainEventHandler<T>>();
            foreach (var handler in handlers)
            {
                handler.Handle(domainEvent);
            }
        }
    }
