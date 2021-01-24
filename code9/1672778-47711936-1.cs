    public class Customer
    {
        private readonly HashSet<Order> _orders = new HashSet<Order>();
        public IEnumerable<Order> Orders => _orders;
        // ...
        internal void AddOrder(Order order)
        {
            _orders.Add(order);
        }
    }
