    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
            Response.StatusDescription = "404 Not Found";
            return View();
        }
    }
