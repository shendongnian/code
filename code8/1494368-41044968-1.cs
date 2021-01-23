    public class MyAwesomeController : Controller
    {
        public ActionResult Index(string code)
        {
            ViewBag.Code = code;
            return View();
        }
    }
