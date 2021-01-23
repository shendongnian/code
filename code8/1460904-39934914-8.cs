     public class Product
    {
        public Product() { Id = Guid.NewGuid(); }
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
         
    public class ProductCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
         /////view model///
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "required")]
        public string ProductName { get; set; }
        public int SelectedValue { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        [DisplayName("Product Category")]
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
