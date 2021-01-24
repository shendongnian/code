    [RoutePrefix("Controller")]
    public class Controller : Controller
    {
         [Route("action/{username}/{userid:int}")]
         public ActionResult Action(string username, int userid){}
    }
