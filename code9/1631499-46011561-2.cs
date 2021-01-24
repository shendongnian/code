    public class HomeController : Controller
    {
        public HomeController(ILoggerFactory loggerFactory, IMyService myServce)
        {
            myServce.DoSomethingPLEASE();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
