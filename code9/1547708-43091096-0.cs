    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content(Request.Headers["Authorization"]);
        }
    }
