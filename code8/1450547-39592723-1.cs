    [RoutePrefix("v1/user/something")]
    public class SomethingsController : ApiController {
        [Route("{id:int}")]
        [HttpGet]
        [ResponseType(typeof(SomethingsViewModel))]
        public async Task<IHttpActionResult> GetAsync([FromUri]int id) { ... }
    }
    
    [RoutePrefix("v1/user")]
    public class UserController : ApiController {
        [Route("{id:int}")]
        [HttpGet]
        [Authorize(Roles = "Super Admin")]
        public async Task<IHttpActionResult> GetByIdAsync([FromUri]int id) { ... }
    }
