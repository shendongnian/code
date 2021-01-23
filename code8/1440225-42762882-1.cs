    public class SomeController : Controller
    {
        public IActionResult SomeAction()
        {
            TempData["SomeProperty"] = "Some data";
        }
    }
