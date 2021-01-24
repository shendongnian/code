    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet("{A}")]
        public IEnumerable<string> Get(int A, int B)
        {
           return new [] { A.ToString(), B.ToString() };
        }
    }
