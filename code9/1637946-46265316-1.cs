    public class Foo
    {
        private readonly _handlerMap = new Dictionary<int, Action>
        {
            { 1, () => handleOpenOrder() },
            { 2, () => handleShippedOrder() },
            { 3, () => handleCanceledOrder() }
        }
        public void TheMethodPreviouslyContainingTheSwitch(Order order)
        {
            var action = _handlerMap[order.OrderStatus.ID];
            action.Invoke();
        }
    }
