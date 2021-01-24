    public class CoreController : Controller
    {
       [HttpGet("/Books/Page/{page?}")]
       public IActionResult Books(int? page) { ... }
    }
