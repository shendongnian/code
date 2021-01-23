    public class HomeController : Controller
    {
        [Authorize] // Authorize the user.
        public ActionResult Index()
        {
            return View();
        }
    }
