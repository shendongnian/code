    [ServiceFilter(typeof(CustomActionFilter))]
    [Route("api/custom")]
    public class CustomController : Controller {
        // GET: api/issues
        [HttpGet]
        [ServiceFilter(typeof(CustomActionFilter))]
        public IActionResult Get() { 
            //...
        }
    }
