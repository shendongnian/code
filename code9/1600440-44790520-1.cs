    [AllowAnonymous]
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            Response.StatusCode = 500;
            return View("Error");
        }
        public ViewResult BadRequest()
        {
            Response.StatusCode = 400;
            return View("BadRequest");
        }
        public ViewResult NotFound()
        {
            Response.StatusCode = 404;
            return View("NotFound");
        }
        public ViewResult NotAuthorized()
        {
            Response.StatusCode = 403;
            return View("NotAuthorized");
        }
    }
