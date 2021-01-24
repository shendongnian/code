    public class FooController : Controller
    {
        [HttpGet("Add")] // Attribute Routing
        public IActionResult Create()
        {
            return View();
        }
    }
