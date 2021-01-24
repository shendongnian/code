    [Route("api/[controller]")]
    public class SalesController : Controller {
        
        [HttpGet("{id:int}")] // GET api/sales/1
        public IActionResult Get(int id) {
            // Logic
        }
        
        [HttpGet] // GET api/sales?page=1 assuming PaginationHelper has page property
        public IActionResult Get([FromQuery]PaginationHelper pagination) {
            // Logic
        } 
        
        [HttpGet("me")] // GET api/sales/me
        public IActionResult GetMe() {
            // Logic
        }  
    }
