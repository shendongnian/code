    public class TestService 
    {
        public void Do()
        {
          // ...
        }
    }
    public class HomeController1 : Controller
    {
        public ActionResult Index()
        {
            var service = new TestService();
            service.Do();
            return View();
        }
    }
    public class HomeController2 : Controller
    {
        public ActionResult Index()
        {
            var service = new TestService();
            service.Do();
            return View();
        }
    }
