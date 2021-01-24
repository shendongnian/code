    public interface IOrderReceiverStrategy
    {
        void OrderReceived(OrderDto orderDto, Action<Exception> callback);
    }
    
    public class OrderReceiverStrategy : IOrderReceiverStrategy
    {
        public void OrderReceived(OrderDto orderDto, Action<Exception> callback)
        {
            try
            {
                // some business logic
    
                callback(null);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
    
                callback(ex);
            }
        }
    }
    
    public class OrderService
    {
        public OrderService(IOrderReceiverStrategy strategy) { }
    
    
        public void OrderReceived(OrderDto orderDto, Action<Exception> callback)
        {
            try
            {
                taskManager.ProcessWorkItem(() => _strategy.OrderReceived(orderDto, callback));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
    
                callback(ex);
            }
        }
    }
