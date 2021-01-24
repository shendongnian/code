    public class ProductFormViewModel
    {
    
        public int Id { get; set; }
    
        [Required]
        public string Name { get; set; }
    
        [Required]
        public decimal? Price { get; set; }
    
        [Required]
        [DisplayName("Stock")]
        public int? StockQuantity { get; set; }
    
        [Required]
        public string Description { get; set; }
    
        [Required]
        [Display(Name="Category")]
        public ICollection<Category> Categories { get; set; }
    
    
        public string Image { get; set; }
        //one to one
        public int CategoryID { get; set; }
        //one to many
        public IEnumerable<int> CategoryIDS { get; set; }
    
    }
