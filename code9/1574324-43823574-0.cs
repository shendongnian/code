    public class Order
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
    
    public class Purchase
    {
        public int Id { get; set; }
        public string Description { get; set;}
        [Index(IsUnique = true)]
        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
