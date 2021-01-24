    public class ErrorController : Controller
    {
        public ActionResult 400()
        {
              throw new HttpException(400, "Bad request");
        }
        public ActionResult 403()
        {
              throw new HttpException(403, "Unauthorized");
        }
        public ActionResult 500()
        {
              throw new HttpException(500, "Server error");
        }        
    }
