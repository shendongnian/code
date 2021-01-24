     public class HomeController : Controller
        {
            // GET: Home
            public ActionResult Index()
            {
                return View();
            }
            public ActionResult Sample()
            {
               string val =  Request.QueryString["id"];
                return View();
            }
        }
