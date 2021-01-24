    public class Product
    {
        public int ProductId { get; set; }
        
        [Required]
        public string ProductName { get; set; }
        [Required]
        [ValidUrl]
        public string ProductThumbnailUrl { get; set; }
    }
