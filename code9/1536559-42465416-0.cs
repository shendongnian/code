    [RoutePrefix("api/user")]
    public class UsersController : ApiController {
    
        //GET api/user/me
        [HttpGet]
        [Route("me")]
        public HttpResponseMessage me() {
            return Request.CreateResponse(HttpStatusCode.OK, "Get me");
        }
    
        //GET api/user/1
        [HttpGet]
        [Route("{id:int")] // NOTE the parameter constraint
        public HttpResponseMessage getUser(int id) {
            return Request.CreateResponse(HttpStatusCode.OK, "Get user");
        }   
    
        //GET api/user
        //GET api/user/OptionalRoleHere
        [HttpGet]
        [Route("{role?}")] //NOTE the question mark used to identify optional parameter
        public HttpResponseMessage Get(string role = null) {
            return Request.CreateResponse(HttpStatusCode.OK, "Get me on role");
        }
    }
