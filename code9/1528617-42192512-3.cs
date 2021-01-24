    public class HomeController : Controller
    {
      [Route("Home/Details/{userName}/{userId}")]
      public ActionResult Details(string userName,int userId)
      {      
        return Content("Details : "+userName + userId);
      }
