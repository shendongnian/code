    public sealed class AsyncScopedMessageHandler<T> : IHandleMessages<T>
    {
        private readonly Container container;
        private readonly Func<IHandleMessages<T>> decorateeFactory;
        public AsyncScopedMessageHandler(Container container, Func<IHandleMessages<T>> factory)
        {
            this.container = container;
            this.decorateeFactory = factory;
        }
        public async Task Handle(T message) {
            using (AsyncScopedLifestyle.BeginScope(this.container)) {
                var decoratee = this.decorateeFactory.Invoke();
                await decoratee.Handle(message);
            }
        }
    }
