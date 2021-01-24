    public class PersistController : Controller
    {
        [HttpPost]
        public ActionResult SaveStyles()
        {
            TempData["Status"] = true;
            TempData["Val"] = 4;
            return Json(true);
        }
    }
    
    public class SettingsController : Controller
    {
        public ActionResult Customize()
        {
            bool status = Convert.ToBoolean(TempData["Status"]);
            int val = Convert.ToInt32(TempData["Val"]);
            return View();
        }
    }
