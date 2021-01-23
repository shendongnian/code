    public class PaymentController : ApiController {
        public string Get() {
            return "get method";
        }
        //GET api/payment/SayHello
        [HttpGet]    
        [Route("~/api/payment/SayHello")]
        public string SayHello() {
            return "Hello Jim";
        }
    }
