    public class Order
    {
        public virtual OrderType Type { get; set; }
    }
    
    public class OrderType
    {
        public virtual ICollection<Order> Orders { get; set; }
    }
