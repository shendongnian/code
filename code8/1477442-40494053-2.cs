        [Route("api/[controller]")]
        public class TestController : Controller{
          [HttpGet]
          public IEnumerable<string> Get() {
            return new string[] { "test1", "test2" };
          }
        }
