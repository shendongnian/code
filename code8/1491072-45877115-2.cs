    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiVersion("2")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpGet("otherget/one")]
        [MapToApiVersion("2")]
        public IEnumerable<string> Get2()
        {
            return new string[] { "value1", "value2" };
        }
        /// <summary>
        /// THIS ONE WILL BE EXCLUDED FROM SWAGGER Ui, BECAUSE v3 IS NOT SPECIFIED. 'DocInclusionPredicate' MAKES THE
        /// TRICK 
        /// </summary>
        /// <returns></returns>
        [HttpGet("otherget/three")]
        [MapToApiVersion("3")]
        public IEnumerable<string> Get3()
        {
            return new string[] { "value1", "value2" };
        }
    }
