    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController {
    
        [HttpGet]
        [Route("")] // Matches GET  api/customers
        public IHttpActionResult GetCustomer(string firstname = null, string status = null) {
            ... some code ...
        }
    }
