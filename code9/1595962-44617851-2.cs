    public class Order
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
    public class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Order Order { get; set; }
    }
