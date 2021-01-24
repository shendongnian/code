    public class Category
        {
            public int CategoryId { get; set; }
            [Required]
            public string CategoryName { get; set; }
    
            public virtual ICollection<Package> Packages { get; set; }
        }
