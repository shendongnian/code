    [Route("api/[controller]")]
    public class CustomersController : Controller 
    {
        [HttpGet]
        public IActionResult Get()
        {   ...   }
        [HttpPost]
        public IActionResult Post()
        {   ...   }
    }
