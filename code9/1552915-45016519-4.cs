    [Authorize(Policy = "EmployeeOnly")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }
        [Authorize(Policy = "HumanResources,SalesOnly")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
