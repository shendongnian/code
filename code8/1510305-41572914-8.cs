    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.UserName = this.UserName();
            return View();
        }
    }
