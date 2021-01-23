    public class htmlController : ApiController
    {
        // GET api/html
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    
        // GET api/html/section
        public string Get(string id)
        {
            if (id == "footer") return "<div>FOO</div>";
            return null;
        }
    }
