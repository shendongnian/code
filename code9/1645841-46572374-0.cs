    static class AggregateConstructors<TAggregate>
    {
        public static Func<Guid, TAggregate> Value { get; private set; }
        public static TAggregate Create(Guid aggregateId) => Value(aggregateId);
    
        static AggregateConstructors()
        {
            var parameter = Expression.Parameter(typeof(Guid), "aggregateId");
            var constructor = typeof(TAggregate).GetConstructor(new[] { typeof(Guid) });
            var lambda = Expression.Lambda<Func<Guid, TAggregate>>(Expression.New(constructor, parameter), parameter);
            Value = lambda.Compile();
        }
    }
    public TAggregate GetAggregate<TAggregate>(Guid aggregateId) where TAggregate : AggregateRoot
    {
        var aggregate = AggregateConstructors<TAggregate>.Create(aggregateId);
        var history = eventStore.GetDomainEvents(aggregateId);
        aggregate.LoadFromHistory(history);
        return aggregate;
    }
