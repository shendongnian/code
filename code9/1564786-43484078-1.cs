    public class ProductsController : ApiController {
        //...constructor code removed for brevity
        [HttpGet]
        public IHttpActionResult GetProducts(int id) {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) {
                return NotFound();
            } 
            return Ok(product);
        }
    }
