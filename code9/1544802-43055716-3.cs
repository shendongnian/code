    [RoutePrefix("Test")]
    public class TestController : ApiController {
        [HttpPost]
        [Route("{message}")]
        public IHttpActionResult EchoBack(string message) { ... }
    }
