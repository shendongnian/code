    public class ProductCategoryModel
    {
       public int CategoryId { get; set; }
       public string Title { get; set; }
    }
    public class ProductsController : ApiController
    {
        [HttpPost]
        public List<Product> GetProductsByCategoryId(ProblemCategoryModel model)
        {
            return new List<Product>
            {
                new Product { Id = 1 , Name = "Test" }
            };
        }
    }
