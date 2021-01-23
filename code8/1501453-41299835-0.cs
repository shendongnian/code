    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()
        {
            if (HttpContext.Session["User"] == null)
            {
                Log(HttpContext.Request.UserHostAddress);
                return View(); // an empty page
            }
            else
            {
                return RedirectToAction("NotFound","Home" ); // Information page for users
            }
        }
    }
