    [RoutePrefix("api/v2/dummy")]
    public class DummyController : ApiController
    {
        // GET api/v2/dummy/get
        [HttpGet]
        [Route("get")]
        [SwaggerOperation("Get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", "value3" };
        }
    }
