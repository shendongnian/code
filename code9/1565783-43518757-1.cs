    public sealed class AsyncScopedMessageHandler<T> : IHandleMessages<T>
    {
        private readonly Container container;
        private readonly Func<IHandleMessages<T>> decorateeFactory;
        public AsyncScopedMessageHandler(Container container,
            Func<IHandleMessages<T>> decorateeFactory) {
            this.container = container;
            this.decorateeFactory = decorateeFactory;
        }
        public Task Handle(T message) {
            using (AsyncScopedLifestyle.BeginScope(this.container)) {
                var decoratee = this.decorateeFactory.Invoke();
                return decoratee.Handle(message);
            }
        }
    }
