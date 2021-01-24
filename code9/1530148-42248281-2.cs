    class ContainerRequestDispatcher : IRequestDispatcher {
        private readonly Container container;
        public ContainerRequestDispatcher(Container container) {
            this.container = container;
        }
        public void Dispatch<TRequest>(TRequest request) {
            var handler = container.GetInstance<IRequestHandler<TRequest>>();
            handler.Handle(request);
        }
    }
