     public class HomeController : Controller
     {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return RedirectToAction("About","Home");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
