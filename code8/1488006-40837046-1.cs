    public class AccountController : Controller
    {
        public ActionResult Test()
        {
            return View();
        }
        public JsonResult AjaxTest(List<string> Names)
        {
            return Json("You posted: " +  Names.Count + " items.", JsonRequestBehavior.AllowGet);
        }
    }
