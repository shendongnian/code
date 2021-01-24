    [RoutePrefix("api/testapi")]
    public class TestApi : ApiController {
    
        [HttpGet]
        [Route("")] //Matches GET api/testapi
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }
    }
