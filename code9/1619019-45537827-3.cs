    [Authorize]
    [RoutePrefix("account")]
    public class AccountController : Controller {
        [AllowAnonymous]
        [Route("sign-in")]        
        public ActionResult Signin(string returnTo) {            
            ViewBag.ReturnTo= returnTo;
            return View(new LoginViewModel { RememberMe = true });
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("sign-in")]   
        public async Task<ActionResult> Signin(LoginViewModel model, string returnTo) {
            //...
        }
        [Route("admin-panel")]
        public Action AdminPanel() {
            return View();
        }
    }
