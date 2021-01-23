    public class TestController : ApiController {
        [HttpPost]
        public IHttpActionResult Post([FromBody]string input) {
            if (input == "Hello From OWIN")
                return Ok("I am working");
            return NotFound();
        }
    }
