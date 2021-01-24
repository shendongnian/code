    public class BaseController : Controller 
    {
        public ActionResult DynamicView(string viewName)
        {
            if (string.IsNullOrWhiteSpace(pageName))
                return RedirectToAction("Index", "Home");
            if (!Regex.IsMatch(viewName, "^[A-Za-z0-9_]+$"))
                return RedirectToAction("NotFound", "Error");
    
            var result = ViewEngines.Engines.FindView(ControllerContext, viewName, null);
            if (result.View == null)
                return RedirectToAction("NotFound", "Error");
            return View(viewName);
        }
    }
