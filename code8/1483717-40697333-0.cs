    public class ProductInstance
    {
        public int Id { get; set; }
    
        public int? SaleId { get; set; }
        public virtual Sale Sale { get; set; }
    }
    
    
    public class Sale
    {
        public int Id { get; set; }
        public virtual ProductInstance ProductInstance { get; set; }
    }
