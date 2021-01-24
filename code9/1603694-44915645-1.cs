    [Route("api/[controller]")]
    public class AdminController : Controller {
     
        [HttpGet("")] //Matches GET api/admin <-- Would also work with [HttpGet]
        public IActionResult Get() {
            return Ok();
        }
        [HttpGet("{id}")] //Matches GET api/admin/5
        public IActionResult Get(int id) {
            return Ok("value");
        }    
        //...other code removed for brevity
    }
