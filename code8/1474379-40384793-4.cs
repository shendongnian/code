    public class ErrorController : Controller
    {    
        [AllowAnonymous]
        public ActionResult BadRequest()
        {
            Response.StatusCode = 403;
            Response.TrySkipIisCustomErrors = true;
    
            return View();
        }    
        [AllowAnonymous]
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
    
            return View();
        }
        [AllowAnonymous]
        public ActionResult Error()
        {
            Response.StatusCode = 503;
            Response.TrySkipIisCustomErrors = true;
    
            return View();
        } 
    }
