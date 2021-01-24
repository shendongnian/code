    [RoutePrefix("Home")]
    public class HomeController : Controller {
        [HttpGet]
        [Route("", Name = "Index")]      //Matches GET /Home
        [Route("Index")]                 //Matches GET /Home/Index
        [Route("~/", Name = "default")]  //Matches GET /  <-- site root
        public ActionResult Index() {
            return View();
        }
        //...
    }
