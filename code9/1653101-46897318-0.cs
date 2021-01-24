    public class Package
        {
            public int PackageId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
            public int CategoryID { get; set; }
    
            
            [Required]
            public virtual Category Category { get; set; }
            public virtual ICollection<Product> Products { get; set; }
    
        }
