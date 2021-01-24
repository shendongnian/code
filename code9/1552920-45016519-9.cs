    [Authorize(Policy = "EmployeeOnly")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Policy = "HumanResources,SalesOnly")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }
    }
