    [Route("product")]
    public class ProductController {
        
        [Route("{productId}"]
        public ActionResult Get(int productId) {
            // your code here
        }
    }
