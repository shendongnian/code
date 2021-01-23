    [RoutePrefix("api/foo/users")]
    public class FirstControllerController : ApiController
    {
        [Route("{id:int}")]
        public string Get(int id)
        {
            return "users ;)";
        }
    }
    [RoutePrefix("api/foo/users/movies")]
    public class SecondControllerController : ApiController
    {
        [Route("")]
        // GET api/values/5
        public string Get()
        {
            return "movies ;)";
        }
    }
