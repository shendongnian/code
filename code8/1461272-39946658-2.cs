    [RoutePrefix("api/payment")]
    public class PaymentController : ApiController {
        //GET api/payment/Get
        [HttpGet]
        [Route("Get")]
        public string Get() {
            return "get method";
        }
        //GET api/payment/Sayhello
        [HttpGet]
        [Route("SayHello")]
        public string SayHello() {
            return "Hello Jim";
        }
    }
