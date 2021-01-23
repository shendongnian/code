    public class Service {
        private readonly IOrderProvider _orderProvider;
    
        public Service(IOrderProvider orderProvider) {
            _orderProvider = orderProvider;
        }
    
        public IOrderProvider OrderProvider => _orderProvider;
    }
