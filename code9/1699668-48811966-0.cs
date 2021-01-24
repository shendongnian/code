        public class Product : Content
        {
            public virtual string NormalizedName { get; set; }
    
            public virtual string ShortDescription { get; set; }
    
            public virtual string Description { get; set; }
    
            public virtual Guid? ThumbnailImageId { get; set; }
    
            [ForeignKey("ThumbnailImageId")]
            public virtual Media ThumbnailImage { get; set; }
            
            [ForeignKey("ProductId")]
            public virtual Guid? ProductId { get; set; }
            [ForeignKey("LinkId")]
            public virtual Guid? LinkId { get; set; }
            public virtual List<Product> ProductLinks { get; set; } = new List<Product>();
        }
