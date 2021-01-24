    public class MagentoOrderStateNotification : INotification
    {
        private readonly GenericRepository<Order> _orderRepository;
        private readonly OMRestIntegrationService _oMRestIntegrationService;
        public MagentoOrderStateNotification(GenericRepository<Order> orderRepository, OMRestIntegrationService oMRestIntegrationService)
        {
            _orderRepository = orderRepository;
            _oMRestIntegrationService = oMRestIntegrationService;
        }
        public void Notify(string Action, int OrderID)
        {
            //implementation...
        }
        public bool AppliesTo(string NotificationName)
        {
            // Note that you can make the criteria to use this
            // service as advanced as you need to. You could even
            // design your strategy to use multiple services in specific
            // scenarios. But putting that logic here has many advantages
            // over a switch case statement.
            return NotificationName == "a";
        }
    }
    public class FooOrderStateNotification : INotification
    {
        public void Notify(string Action, int OrderID)
        {
            //implementation...
        }
        public bool AppliesTo(string NotificationName)
        {
            return NotificationName == "b";
        }
    }
