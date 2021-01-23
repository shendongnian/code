    public class Order
    {
        [ForeignKey("Type")]
        public long TypeId{ get; set; } //Can also be nullable (long?) if you want
        public virtual OrderType Type { get; set; }
    }
    
    public class OrderType
    {
        [Key]
        public long Id { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
