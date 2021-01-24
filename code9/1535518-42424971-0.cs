    [RoutePrefix("api/products")]
    public class ProductsController : ApiController {
        //GET api/products
        [HttpGet]
        [Route("")]
        public IQueryable<IProduct> GetProducts() {
            return db.GetProducts();
        }    
    
        //GET api/products/1
        [HttpGet]
        [Route("{productID:int}")]
        public IProduct GetProduct(int productID) {
            return db.GetProduct(productID);
        }
    }
