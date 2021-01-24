    public class Y : Controller
    {
        public ActionResult Index()
        {
             return RedirectToAction("Login", "User", new { area = "X" });
        }
    }
