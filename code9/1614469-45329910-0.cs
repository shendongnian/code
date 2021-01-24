    public class Review
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
          [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
