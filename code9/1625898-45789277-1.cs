     public class FooController : Controller
        {
            [HttpGet] // Remove "Add"
            public IActionResult Create()
            {
                return View();
            }
        }
       
