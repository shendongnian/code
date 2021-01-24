    [Route("iputwhatiwant")]
    public class HomeController : Controller
    {
         [HttpGet("actionnameiwant")]
         public IActionResult Index()
         {
            return View();
         }
    }
