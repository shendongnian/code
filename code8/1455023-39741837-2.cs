    [RoutePrefix("V2/Home")]
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("{name}", Name = "GetData")]
        public IHttpActionResult GetData(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("username can not be empty");
            }
            return Ok("Test Done");
        }
    }
