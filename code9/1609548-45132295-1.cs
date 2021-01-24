    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public string CartId { get; set; }
        public int ProductId { get; set; }
        public int UserProductsId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual Product Product { get; set; }
        public virtual UserProducts UserProducts { get; set; }
    }
