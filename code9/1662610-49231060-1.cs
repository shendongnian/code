    public class MediatRWrapper : IDomainMediator
    {
        private readonly MediatR.IMediator _mediator;
        public MediatRWrapper(MediatR.IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public Task Publish<TNotification>(TNotification notification,
            CancellationToken cancellationToken = default(CancellationToken))
            where TNotification : IDomainNotification
        {
            var notification2 = new NotificationWrapper<TNotification>(notification);
            return _mediator.Publish(notification2, cancellationToken);
        }
    }
    public class NotificationWrapper<T> : MediatR.INotification
    {
        public T Notification { get; }
        public NotificationWrapper(T notification)
        {
            Notification = notification;
        }
    }
    public class NotificationHandlerWrapper<T1, T2> : MediatR.INotificationHandler<T1>
        where T1 : NotificationWrapper<T2>
        where T2 : IDomainNotification
    {
        private readonly IEnumerable<IDomainNotificationHandler<T2>> _handlers;
        //the IoC should inject all domain handlers here
        public NotificationHandlerWrapper(
               IEnumerable<IDomainNotificationHandler<T2>> handlers)
        {
            _handlers = handlers ?? throw new ArgumentNullException(nameof(handlers));
        }
        public Task Handle(T1 notification, CancellationToken cancellationToken)
        {
            var handlingTasks = _handlers.Select(h => 
              h.Handle(notification.Notification, cancellationToken));
            return Task.WhenAll(handlingTasks);
        }
    }
