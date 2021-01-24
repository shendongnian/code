    public class UserController : ApiController
    {
        [HttpPost]
        [Route("api/user/create")]
        public void Create([FromBody] string email)
        {
        }
    }
