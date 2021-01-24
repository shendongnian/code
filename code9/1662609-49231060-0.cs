    public interface IDomainMediator
    {
        Task Publish<TNotification>(TNotification notification,
            CancellationToken cancellationToken = default(CancellationToken))
            where TNotification : IDomainNotification;
    }
    public interface IDomainNotification
    {}
    public interface IDomainNotificationHandler<in TNotification>
        where TNotification : IDomainNotification
    {
        Task Handle(TNotification notification, 
            CancellationToken cancellationToken=default(CancellationToken));
    }
