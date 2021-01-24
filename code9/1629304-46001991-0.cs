    public class ErrorController : Controller
    {
        public ActionResult Handler(HttpException exception)
        {
            Response.ContentType = "text/html";
            if (exception != null)
            {
                Response.StatusCode = exception.GetHttpCode();
                Response.StatusDescription = exception.Message;
                ViewBag.StatusString = (HttpStatusCode)exception.GetHttpCode();
    
                return View("Handler", exception);
            }
    
            return View("Internal");
        }
    }
