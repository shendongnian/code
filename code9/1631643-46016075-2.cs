    [RoutePrefix("Events")]
    public class EventsController : ApiController {
    
        [Authorize(AuthenticationType.Admin, AuthenticationType.Api, AuthenticationType.User)]
        [HttpGet]
        [Route("")] //Matches GET => /Events
        public async Task<IHttpActionResult> Get() { 
            var user = User.Identity;
            if(user.AuthenticationType == AuthenticationType.User) {
                //...User specific code
            } else {
                //...Admin, API specific code
            }
        }
    
    }
