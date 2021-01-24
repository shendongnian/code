    [Route("iputwhatiwant")]
    public class HomeController : Controller
    {
         [HttpGet]
         [Route("actionnameiwant")]
         public IActionResult Index()
         {
            return View();
         }
    }
