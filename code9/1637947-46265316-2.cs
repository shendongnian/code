    public interface IOrderHandler
    {
        int StatusId { get; }
        void Handle(Order order);
    }
    public class OpenOrderHandler : IOrderHandler
    {
        public int StatusId => 1;
        public void Handle(Order order)
        {
            // ...
        }
    }
    public class OrderHandlerFactory
    {
        // this factory could be injected to all you dependant classes that need
        // handlers to handle orders
        private readonly _handlerMap = new Dictionary<int, Action>
        {
            // defining the IDs here and in the classes' defintions may be a bit 
            // redudant, but... meh ;)
            { 1, () => new OpenOrderHandler() },
            { 2, () => new ShippedOrderHandler() },
            { 3, () => new CancledOrderHandler() }
        }
        public IOrderHandler CreateHandlerByStatus(int orderStatusId)
        {
            // if the creation of a handler is expensive, it may be useful to
            // only create a single handler that matches the orderStatusId
            var action = _handlerMap[orderStatusId];
            var handler = action.Invoke();
            return handler;
        }
        public ICollection<IOrderHandler> CreateHandlers()
        {
            // it may be fine to create all handlers in each call of this method
            // if the creation is inexpensive
            return _handlerMap.Select(kvp => kvp.Value.Invoke()).ToList();
        }
    }
    public class Foo
    {
        private readonly OrderHandlerFactory _orderHandlerFactory;
        public Foo(OrderHandlerFactory orderHandlerFactory)
        {
            _orderHandlerFactory = orderHandlerFactory;
        }
        public void TheMethodPreviouslyContainingTheSwitch(Order order)
        {
            var handler = _orderHandlerFactory.CreateHandlerByStatus(order.OrderStatus.ID);
            handler.Handle(order);
        }
        public void ThisMayBeUsefulIfMultipleHandlersRelateToAcertainStatus(Order order)
        {
            var handlers = _orderHandlerFactory.CreateHandlers();
            handlers
                .Where(handler => handler.StatusId == order.OrderStatus.ID)
                .All(handler => handler.Handle(order));
        }
    }
