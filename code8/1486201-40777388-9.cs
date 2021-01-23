    [RoutePrefix("api/users")]
    public class UsersController : ApiController {
        // GET:  api/Users              returns a list (all)
        [HttpGet]
        [Route("")] 
        public IHttpActionResult Get() { ... }
        // GET:  api/Users/5            returns the user with Id 5
        [HttpGet]
        [Route("{id:int}")] 
        public IHttpActionResult Get(int id) { ... }
        // GET:  api/Users/Active       returns a list (only those not soft-deleted)
        [HttpGet]
        [Route("Active")] 
        public IHttpActionResult Active() { ... }
        // POST: api/Users              creates a user
        [HttpPost]
        [Route("")] 
        public IHttpActionResult Post(User user) { ... }
    }
