    [Route("[controller]")]
    public class HomeController : Controller
    {
         [HttpGet("[action]")]
         public IActionResult Index()
         {
            return View();
         }
    }
