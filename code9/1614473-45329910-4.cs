    public class CreateProductRequest
    {
        [Required]
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        //Navigation Property
        public IEnumerable<CreateReviewRequest> Reviews { get; set; }
    }
    public class CreateReviewRequest
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
