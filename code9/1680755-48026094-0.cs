    public class CategoryCreate : Category
    {
        [Required]
        public override string Name { get; set; }
        [Required]
        public override Permission Permission { get; set; }
    }
