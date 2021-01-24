    [Route("users")]
    public class UsersController : ApiController
    {
        [Route("")]
        public IHttpActionResult GetUsers()
        {
            string test = "";
            return Ok(test);
        }
        [Route("{id}")]
        public IHttpActionResult GetUsers(Guid id)
        {
            string test = "";
            return Ok(test);
        }
        [Route("{CodeA}/{CodeB}")]
        public IHttpActionResult GetUsers(string CodeA, string CodeB)
        {
            string test = "";
            return Ok(test);
        }
    }
