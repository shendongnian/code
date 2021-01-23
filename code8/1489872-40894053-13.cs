    [RoutePrefix("api/some-resources")]
    public class CreationController : ApiController {
        [HttpPost("")]
        public IHttpActionResult CreateResource(CreateData input) {
            return Ok();
        }
    }
    [RoutePrefix("api/some-resources")]
    public class DisplayController : ApiController {
        [HttpGet("")]
        public IHttpActionResult ListAllResources() {
            return Ok();
        }
        [HttpGet("{publicKey:guid}")]
        public IHttpActionResult ShowSingleResource(Guid publicKey) {
            return Ok();
        }
    }
