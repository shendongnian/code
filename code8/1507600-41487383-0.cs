    [RoutePrefix("user")]
    public class UserController: ApiController
    {
        //GET user
        [Route("")]
        [HttpGet]
        public IEnumerable<User> Get() { ... }
    
        //GET user/Jane
        [Route("{name}")]
        [HttpGet]
        public IEnumerable<User> GetByName(string name) { ... }
    }
