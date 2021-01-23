    [RoutePrefix("api/Order")]
    public class OrderController : ApiController
    {
        [Route("~/api/Order/{id}")]
        [HttpGet]
        public Task<HttpResponseMessage> Get(Guid id)
        {
            //Implementation
        }
    
        [Route("ExampleOtherNormalMethod")]
        [HttpGet]
        public Task<HttpResponseMessage> ExampleOtherNormalMethod()
        {
            //Implementation
        }
    }
    
    [RoutePrefix("api/ManualOrder")]
    public class ManualOrderController : OrderController 
    {
        [Route("~/api/ManualOrder/{id}")]
        [HttpGet]
        public Task<HttpResponseMessage> Get(Guid id)
        {
            return base.Get(id);
        }
    
        //Other methods
    }
