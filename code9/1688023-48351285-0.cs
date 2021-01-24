    public class HomeController : Controller
    {
        private readonly TestClass _testClass;
        public HomeController(TestClass testClass)
        {
            _testClass = testClass;
        }
        public IActionResult Index()
        {
            var data = _testClass.DoSomething();
            return View(data);
        }
    }
