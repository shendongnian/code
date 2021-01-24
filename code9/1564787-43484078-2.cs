    [RoutePrefix("api/products")]
    public class ProductsController : ApiController {
        //...constructor code removed for brevity
        [HttpGet]
        [Route("{id:int}")] // Matches GET api/products/1
        public IHttpActionResult GetProducts(int id) {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) {
                return NotFound();
            } 
            return Ok(product);
        }
    }
