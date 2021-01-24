    public class ErrorController : Controller
    {
        public ActionResult BadRequest()
        {
              throw new HttpException(400, "Bad request");
        }
        public ActionResult Unauthorized()
        {
              throw new HttpException(403, "Unauthorized");
        }
        public ActionResult ServerError()
        {
              throw new HttpException(500, "Server error");
        }        
    }
