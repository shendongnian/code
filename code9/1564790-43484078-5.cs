    [RoutePrefix("api/products")]
    public class ProductsController : ApiController {
        //...constructor code removed for brevity
        [HttpGet]
        [Route("")] // Matches GET api/products
        public IHttpActionResult GetAllProducts() {
            return Ok(products);
        }
        [HttpGet]
        [Route("{id:int}")] // Matches GET api/products/1
        public IHttpActionResult GetProduct(int id) {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) {
                return NotFound();
            } 
            return Ok(product);
        }
    }
