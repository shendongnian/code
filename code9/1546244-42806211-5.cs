    [RoutePrefix("api/RegisterUser")]
    public class UsersController : ApiController {
    
        [HttpPost]
        [Route("Authenticate")]
        public IHttpActionResult GetUserAuthenticated([FromBody]AuthenticateViewModel model){
             var userName = model.Username;
             var pwd = model.Password;
             // Code logic here.
             return Ok(model);
        }
    }
