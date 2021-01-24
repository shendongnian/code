    // Option 1:
    public class CustomerMap : ClassMapping<Customer>
    {
        public CustomerMap()
        {
            // ...
    
            Bag<Order>("_orders", collectionMapping =>
            {
                //...
            },
            map => map.ManyToMany(p => p.Column("OrderId")));
        }
    }
    
    // Option 2: No strings, but I'm not sure if this one would really work as is.
    public class CustomerMap : ClassMapping<Customer>
    {
        public CustomerMap()
        {
            // ...
    
            Bag(x => x.Orders, collectionMapping =>
            {
                collectionMapping.Access(Accessor.Field),
                    
                //...
            },
            map => map.ManyToMany(p => p.Column("OrderId")));
        }
    }
    
    // Option 3: No strings, but more convoluted.
    public class Customer
    {
        internal class PrivatePropertyAccessors
        {
            public static Expression<Func<Customer, IEnumerable<Order>>> OrdersProperty = c => c._orders;
        }
    
        private readonly IList<Order> _orders = new List<Order>();
    
        public IEnumerable<Order> Orders
        {
            get { foreach (var order in _orders) yield return order; }
        }
    }
    
    public class CustomerMap : ClassMapping<Customer>
    {
        public CustomerMap()
        {
            // ...
    
            Bag(Customer.PrivatePropertyAccessors.OrdersProperty, collectionMapping =>
            {
                //...
            },
            map => map.ManyToMany(p => p.Column("OrderId")));
        }
    }
