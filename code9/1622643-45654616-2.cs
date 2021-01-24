    [RouteArea("AreaName", AreaPrefix = "app/accounts")]
    public class AccountsController : Controller {
        [HttpGet]
        [Route("list/{id:int}")] // Matches GET app/accounts/list/45646
        public ActionResult List(int id) {
            return View();
        }
    }
