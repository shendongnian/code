    [Authorize]
    [RoutePrefix("account")]
    public class AccountController : Controller {
        [Route("sign-in")]        
        public ActionResult Signin(string returnTo) {            
            ViewBag.ReturnTo = returnTo;
            return View(new LoginViewModel { RememberMe = true });
        }    
        [Route("admin-panel")]
        public Action AdminPanel() {
            return View();
        }
    }
