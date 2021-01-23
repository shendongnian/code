    [RoutePrefix("api/{apiVersion:apiVersionConstraint(v1)}/values")]
    public class ValuesController : ApiController
    {
        // GET api/v1/values
        [Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "v1-value1", "v1-value2" };
        }
    
        // GET api/v1/values/5
        [Route("{id}")]
        public string Get(int id)
        {
            return "v1-value-" + id;
        }
    }
