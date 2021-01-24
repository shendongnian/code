    [Authorize]
    public class AccountController : Controller {
        [Route("account/admin-panel")]
        public Action AdminPanel() {
            return View();
        }
    }
    
    public class AuthenticationController : Controller {
        [Route("account/sign-in")]        
        public ActionResult Signin(string returnTo) {            
            ViewBag.ReturnTo= returnTo;
            return View(new LoginViewModel { RememberMe = true });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("account/sign-in")]   
        public async Task<ActionResult> Signin(LoginViewModel model, string returnTo) {
            //...
        }
    }
