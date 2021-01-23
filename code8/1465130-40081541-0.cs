    public class DummyController : ApiController
    {
        // GET api/values
        [HttpGet]
        [Route("api/v2/dummy/get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", "value3" };
        }
    }
