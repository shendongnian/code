    [Route("[controller]")]
    public class HomeController : Controller
    {
         [HttpGet]
         [Route("[action]")]
         public IActionResult Index()
         {
            return View();
         }
    }
