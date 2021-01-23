    public class AccountController : Controller
    {
        // This returns the view with the form
        public ActionResult Test()
        {
            return View();
        }
        public JsonResult AjaxTest(Person person)
        {
            return Json("Welcome" +  person.Name, JsonRequestBehavior.AllowGet);
        }
    }
