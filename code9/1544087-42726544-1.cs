    public class Order
    {
        [Key, ForeignKey("Product")]
        public int OrderId { get; set; }
        public int Amount { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
