    [RoutePrefix("api/Users")]
    public class UsersController : ApiController {
        private Model1Container db = new Model1Container();
    
        [HttpGet]
        [Route("")] //Matches GET api/Users
        public IEnumerable<User> GetUsers() {
            return db.UserSet;
        }
    
        [HttpPost]
        [Route("SignIn")] //Matches POST api/Users/SignIn
        public IHttpActionResult SignIn(string account, string password) {
            //...
        }
    
        [HttpPost]
        [Route("SignUp")] //Matches POST api/Users/SignUp
        public IHttpActionResult SignUp([FromBody]User user) {
            //...
        }
    
        [HttpGet]
        [Route("{id:int}")] //Matches GET api/Users/5
        public IHttpActionResult GetUser(int id) {
            //...
        }
    
        [HttpPut]
        [Route("{id:int}")] //Matches PUT api/Users/5
        public IHttpActionResult PutUser(int id,[FromBody]User user) {
            //...
        }
    
        [HttpDelete]
        [Route("{id:int}")] //Matches DELETE api/Users/5
        public IHttpActionResult DeleteUser(int id) {
            //...
        }
    } 
