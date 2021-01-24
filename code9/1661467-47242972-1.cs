    [Route("api/employees")]
    public class TestController : Controller
    {
        [HttpGet]
        public JsonResult GetEmployees() { ... }
        // or this, but not recommended, to to harder maintenance. Notice the slash in front of the route
        [HttpGet("/api/employees")]
        public JsonResult GetEmployees() { ... }
    }
