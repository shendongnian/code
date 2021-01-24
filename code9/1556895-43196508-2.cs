    [Route("")]
    public class RootController : Controller {
        [HttpGet] //Matches GET /
        public IActionResult Get() {
            return Ok("hello world");
        }
        [HttpGet("echo/{value}] //Matches GET /echo/anything-you-put-here
        public IActionResult GetEcho(string value) {
            return Ok(value);
        }
    }
