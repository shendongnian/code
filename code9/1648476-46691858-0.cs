    [Route("templates")]
    public class TemplatesController : Controller
    {
        [HttpGet("byname/{name}")]
        public IActionResult GetByName(string name)
        {
            return Ok("ByName");
        }
        [HttpGet("bytype/{type}")]
        public IActionResult GetByType(string type)
        {
            return Ok("ByType");
        }
    }
