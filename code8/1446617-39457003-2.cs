    namespace BeerDev.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                ViewBag.Title = "Home";
    
                return View();
            }
        }
    }
