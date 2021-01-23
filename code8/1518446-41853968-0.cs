    [RouterPrefix("quotation")]
    public class SaleOrderController : ApiController {
    
        //GET quotation
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll() { ... }
    
    }
