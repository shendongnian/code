    [UseWebApiRoutes]
    [UseWebApiActionConventions]    
    public class BaseController : Controller {
        
    }
    public class TestController : BaseController {
        // maps to GET /api/Test
        // no attributes
        public IActionResult Get(string p) {
            return new ObjectResult(new { Test = p });
        }
    }
