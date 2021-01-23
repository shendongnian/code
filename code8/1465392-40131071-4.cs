    public class HtmlController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        public string Get(string id)
        {
            if (id == "footer") return "<div>FOO</div>";
            return null;
        }
    }
