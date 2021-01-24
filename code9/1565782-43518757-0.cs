    public sealed class AsyncScopedMessageHandlerProduct<T> : IHandleMessages<T>
    {
        private readonly Container container;
        private readonly Func<IHandleMessages<T>> decorateeFactory;
        public AsyncScopedMessageHandlerProduct(Container container,
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
