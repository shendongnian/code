    [Route("api/[controller]")]
    public class ValController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        // POST api/<controller>
        public String Post([FromBody]string value)
        {
           return "Test";              
        }
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
