    public class HomeController : Controller
    {       
        public ActionResult Foo()
        {
            return View(new TestResult());
        }
        [HttpPost]
        public ActionResult Foo(TestResult t)
        {
            return View(t);
        }
    }
    public class TestResult
    {
        public string SelectedRegex { get; set; }
    }
