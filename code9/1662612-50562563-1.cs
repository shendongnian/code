    public class DomainEventDispatcher : IDomainEventChangesConsumer
    {
        private readonly IMediator _mediator;
        public DomainEventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }
        public void Consume(IAggregateId aggregateId, IReadOnlyList<IDomainEvent> changes)
        {
            foreach (var change in changes)
            {
                var domainEventNotification = CreateDomainEventNotification((dynamic)change);
                _mediator.Publish(domainEventNotification);
            }
        }
        private static DomainEventNotification<TDomainEvent> CreateDomainEventNotification<TDomainEvent>(TDomainEvent domainEvent) 
            where TDomainEvent : IDomainEvent
        {
            return new DomainEventNotification<TDomainEvent>(domainEvent);
        }
    }
