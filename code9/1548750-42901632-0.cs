    public class ErrorController : Controller 
    {
            public ActionResult Index()
            {
                return View("Index");
            }
        
            public ActionResult NotFound()
            {
                return View("NotFound");
            }
            public ActionResult BadRequest()
            {
                return View("BadRequest");
            }
        
            public ActionResult ServerError()
            {
                return View("ServerError");
            }
        }
