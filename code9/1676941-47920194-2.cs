    // mark with these attributes for it to work
    [UseWebApiRoutes]
    [UseWebApiActionConventions]
    public class TestController : Controller {
        // maps to GET /api/Test
        public IActionResult Get() {
            return new ObjectResult(new { Test = "a" });
        }
    }
