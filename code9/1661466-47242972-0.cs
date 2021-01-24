    public class TestController : Controller
    {
        // This route is relative to the /test path, because that's the name of the controller
        [HttpGet("api/employees")]
        public JsonResult GetEmployees() { ... }
    }
