    // mark with these attributes for it to work
    [UseWebApiRoutes]
    [UseWebApiActionConventions]
    public class TestController : Controller {
        // maps to GET /api/Test
        // no routing attributes, but two "conventions" attributes
        public IActionResult Get(string p) {
            return new ObjectResult(new { Test = p });
        }
    }
