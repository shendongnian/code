        public class Defects
        {
            public long Id { get; set; }
    
            
            [ForeignKey("Product")]
            public int ProductId { get; set; }
    
            
            public Products Product { get; set; }
        }
