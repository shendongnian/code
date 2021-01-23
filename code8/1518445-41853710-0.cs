    [RoutePrefix("quotation")]
    public class SaleOrderController : ApiController
    {
        [Route("example")]
        [HttpGet]
        public IHttpActionResult Example()
        {
            return Ok();
        }
        [Route("another")]
        [HttpGet]
        public IHttpActionResult Another()
        {
            return Ok();
        }
    }
