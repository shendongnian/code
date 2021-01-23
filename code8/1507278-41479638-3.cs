    public class ProductCategoryModel
    {
       public int CategoryId { get; set; }
       public string Title { get; set; }
    }
    public class ProductsController : ApiController
    {
        [HttpPost]
        public List<Product> GetProductsByCategoryId(ProductCategoryModel model)
        {
            return new List<Product>
            {
                new Product { Id = 1 , Name = "Test" }
            };
        }
    }
