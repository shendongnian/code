    [UseWebApiRoutes]
    [UseWebApiActionConventions]    
    public class BaseController : Controller {
        
    }
    public class TestController : BaseController {
        // maps to GET /api/Test
        public IActionResult Get() {
            return new ObjectResult(new { Test = "a" });
        }
    }
