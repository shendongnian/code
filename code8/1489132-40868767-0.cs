    [Route("api/[controller]")]
    public class BXLogsController : Controller {
        //GET api/BXlogs/id/blah
        [HttpGet("ID/{id}", Name = "GetL")]
        public IActionResult GetById(string id) { ... }
    
        //GET api/BXlogs/api/blahapi
        [HttpGet("API/{apiname}", Name = "GetLAPI")]
        public IActionResult GetByAPI(string apiname) { ... }
    }
