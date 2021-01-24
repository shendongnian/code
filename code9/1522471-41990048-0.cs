    public class ErrorController : Controller
    {
        [Route("error/404")]
        public ActionResult Error404()
        {
            return View("404");
        }
    
        [Route("error/500")]
        [Route("error/exception")]
        public ActionResult Error500()
        {
            return View("500");
        }
    
        [Route("error/test")]
        public ActionResult Test()
        {
            return new StatusCodeResult(500);
        }
            
    } 
