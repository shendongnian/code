    public class QueryParameters
    {
        [Required]
        public int A { get; set; }
        public int B { get; set; }
    }
    
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        // [HttpGet] isn't needed as it is the default method, but ok to leave in
        // QueryParameters is injected here, the framework takes what is in your query string and does its best to match any parameters the action is looking for. In the case of QueryParameters, you have A and B properties, so those get matched up with the a and b query string parameters
        public IEnumerable<string> Get(QueryParameters parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // or whatever you want to do
            }
            return new [] { parameters.a.ToString(), parameters.b.ToString() };
        }        
    }
