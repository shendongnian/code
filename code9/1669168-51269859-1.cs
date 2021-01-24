    [Authorize(Roles = "Administrator")]
    public class ControlPanelController : Controller
    {
        public ActionResult SetTime()
        {
        }
    
        [AllowAnonymous] // resets authorization
        [Authorize(Roles = "Administrator, Manager")]
        public ActionResult Login()
        {
        }
    }
