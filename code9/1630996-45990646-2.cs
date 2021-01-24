    [Authorize(Roles = "CanViewHome")]
    public class IndexController : Controller
    {
        [Authorize(Roles = "CanEditHome")]
        public ActionResult Edit()
        {
            return View();
        }
    }
