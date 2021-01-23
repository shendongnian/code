    public class BaseController : Controller
    {
        public const string actvStat = "Active";
        public const string inctvStat = "Inactive";
        public ActionResult Index()
        {
            return View();
        }
    }
    public class Variables
    {
        public const string actvStat = "Active";
        public const string inctvStat = "Inactive";
    }
