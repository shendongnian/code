    [RoutePrefix("Events")]
    public class EventsController : ApiController {
    
        [Authorize(AuthenticationType.Admin, AuthenticationType.Api)]
        [HttpGet]
        [Route("")] //Matches GET => /Events
        public async Task<IHttpActionResult> Get() { 
            //...
        }
    
        [Authorize(AuthenticationType.User)]
        [HttpGet]
        [Route("{id:int}")] //Matches GET => /Events/12345
        public async Task<IHttpActionResult> Get(int id) { 
            //...
        }
    }
