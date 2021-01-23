    public class PaymentController : ApiController
    {
        public string Get()
        {
            return "get method";
        }
    
        [Route("~/api/payment/SayHello")]
        public string SayHello()
        {
            return "Hello Jim";
        }
    }
