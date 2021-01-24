    [Route("MySpecialSauce")]
    public class ProductsController : Controller {
        
        [HttpGet("GetBy/{id:int}")]//Matches GET MySpecialSauce/GetBy/5
        public MyObject GetBy(int id) {
            return something(id);
        }
    }
