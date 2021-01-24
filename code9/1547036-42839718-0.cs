       public class Products
        {
            public int Id { get; set; }
    
            public virtual List<Defects> Bundle { get; set; }
        }
    
    
        public class Defects
        {
            public long Id { get; set; }
    
            
            public int ProductId { get; set; }
    
            [ForeignKey("ProductId")]
            public Products Product { get; set; }
        }
