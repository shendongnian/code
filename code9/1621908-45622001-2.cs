    public class BillingConroller : ApiController {    
        [HttpPost]
        public bool PayAuthNet([FromBody] AuthnetTransModel model) {
           return authorizeNetWrapper.Execute<BillingConroller>(c => c.PayAuthNet(model));
        }    
    }
