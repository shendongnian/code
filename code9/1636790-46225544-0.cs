    [RoutePrefix("Home")]
    public class HomeController : Controller {
        [HttpGet]
        [Route("", Name = "Index")] //Matches GET /Home
        [Route("Index")] //Matches GET /Home/Index
        [Route("~/", Name = "default")] // Matches GET /
        public ActionResult Index() {
            return View();
        }
        //...
    }
