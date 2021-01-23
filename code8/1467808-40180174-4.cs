    [ApiVersion1RoutePrefix("products")]
    public class ProductsController : ApiController {
        Product[] products = new Product[] {
            new Product { UserReference = "a", Name = "product1" },
            new Product { UserReference = "b", Name = "product2" }
        };
    
        [HttpGet]
        [Route("")]
        public IEnumerable<Product> GetAllProducts() {
            return products;
        }
    
        [HttpGet]
        [Route("{userReference}")]
        public IHttpActionResult GetProducts(string userReference) {
            var res = products.Where(t => t.UserReference == userReference);
    
            if (res == null)
                return NotFound();
    
            return Ok(res);
        }
    }
