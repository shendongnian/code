    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [MyActionFilter]
        public IActionResult About()
        {
            return View();
        }
    }
