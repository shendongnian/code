    [Authorize]
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.UserName = UserName;
            return View();
        }
    }
