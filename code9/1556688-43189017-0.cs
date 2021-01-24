    [Route("MySpecialSauce")]
    public class ProductsController : Controller {
        //GET MySpecialSauce/GetBy/5
        [HttpGet("GetBy/{id:int}")]
        public MyObject GetBy(int id) {
            return something(id);
        }
    }
