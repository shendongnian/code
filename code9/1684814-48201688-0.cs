    [Route("api/[controller]")]
    public class DefaultController<T> : ApiController
    {
        // GET: api/{ControllerName}
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "first", "second" };
        }
        // GET: api/{ControllerName}/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
