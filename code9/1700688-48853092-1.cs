    // This class depends on the Container and should therefore be part of
    // your Composition Root
    public class ScopingOrderServiceDecorator : IOrderService
    {
        // Depend on the Container
        private readonly Container container;
        // Wrap a Func<IOrderService>. This allows the 'real' `IOrderService`
        // to be created by the container within the defined scope.
        private readonly Func<IOrderService> decorateeFactory;
        ScopingOrderServiceDecorator(Container container, Func<IOrderService> decorateeFactory)
        {
            this.container = container;
            this.decorateeFactory = decorateeFactory;
        }
        public void CancelOrder(Guid orderId)
        {
            // Create a new scope
            using (AsyncScopedLifestyle.BeginScope(this.container))
            {
                // Within the scope, invoke the factory. That ensures an instance
                // for this scope.
                IOrderService decoratee = this.decorateeFactory.Invoke();
                // Forward the call to the created decoratee
                decoratee.CancelOrder(orderId);
            }
        }
    }
