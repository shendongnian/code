    public class ProductInstance
    {
        public int Id { get; set; }
    
        public virtual Sale Sale { get; set; }
    }
    
    
    public class Sale
    {
        [Key]
        [ForeignKey("ProductInstance")]
        public int ProductInstanceId { get; set; }
      
       ///write here other properties
        public virtual ProductInstance ProductInstance { get; set; }
    }
