    public class HomeController : Controller
    {
      [AccessDeniedAuthorize(Roles = "Admin, HrAdmin")]
      public ActionResult PayRoll()
      {
          return View();
      }
    }
