    public class OrderItem
    {
        public int OrderId { get; set;}
    
        public virtual Order Order { get; set; }
    }
    
    public class Order
    {
        public int Id { get; set; }
    
        public virtual OrderItem OrderItem { get; set; }
    }
