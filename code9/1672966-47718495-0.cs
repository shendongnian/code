    public class AccountController : Controller
    {   
        [HttpGet]
        public ActionResult Login()
        {
             // shows the login page
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Login(LoginViewModel model)
        {
             // Process login
        }
    }
