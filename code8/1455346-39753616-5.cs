    [Route("api/[controller]")]
    public class ValuesController : Controller {
        public ValuesController(ITester tester) {
            //do something with tester..
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }
    }
