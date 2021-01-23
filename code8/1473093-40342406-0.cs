    public class ContentServerController : Controller
    {
        public ActionResult Index(string contRep, string docId, string pVersion)
        {
            return RedirectToAction(Request.QueryString[0]);
        }
        public ActionResult info(string contRep, string docId, string pVersion)
        {
            return Content("info action");
        }
    }
