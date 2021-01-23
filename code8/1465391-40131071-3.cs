    [RoutePrefix("api/html")]
    public class htmlController : ApiController
    {
        // GET api/html
        [Route("footer")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    
        // GET api/html/section
        [Route("footer/{id}")]
        public string Get(string id)
        {
            if (id == "footer") return "<div>FOO</div>";
            return null;
        }
    }
