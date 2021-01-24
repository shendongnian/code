    [RoutePrefix("")]
    public class HomeController : Controller
    {
        [Route("{id?}")]
        public ActionResult WebPage(string id)
		{
           return View();
        }
    }
