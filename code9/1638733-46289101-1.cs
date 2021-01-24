    public class ErrorController : Controller
    {
        public ActionResult PageNotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
