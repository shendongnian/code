    public class ProductsController : ApiController
    {
        [HttpPost]
        public List<Product> GetProductsByCategoryId([FromBody]int categoryId, [FromBody]string title)
        {
            return new List<Product>
            {
                new Product { Id = 1 , Name = "Test" }
            };
        }
    }
