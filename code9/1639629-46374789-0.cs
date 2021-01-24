    [CustomAuthorise(SuperAdministrator, Administrator)]
    public class PrivilegedController : Controller
    {
    
        // Should only accessible by SuperAdministrators and Administrators
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    
    }
    
    [CustomAuthorise(SuperAdministrator, Administrator, Consultant)]
    public class LessPrivilegedController : Controller
    {
    
        [HttpGet]
        public ActionResult SomeAction()
        {
            return View();
        }
    }
