     [RoutePrefix("hometest")]
        public class HomeController : Controller
        {
            [Route]
            public ActionResult Index()
            {
                return View();
            }
    
              [Route("About")]
            public ActionResult About()
            {
                ViewBag.Message = "Your application description page.";
    
                return View();
            }
    }
