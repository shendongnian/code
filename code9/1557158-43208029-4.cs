    [RoutePrefix("Login")]
    public class LoginController : Controller {
        [Route("")]
        public ActionResult Login() {
            //Clear previous credentials
            if (Request.IsAuthenticated) {
                FormsAuthentication.SignOut();
                Session.RemoveAll();
                Session.Clear();
                Session.Abandon();
            }
            return View();
        }
        [Route("")]
        [HttpPost]
        public ActionResult TryLogin(string username, string password) {
			//Verify username and password however you need to
            FormsAuthentication.RedirectFromLoginPage(username, true);
            return null;
        }
        [Route("Windows")]
        public ActionResult Windows() {
            var principal = Thread.CurrentPrincipal;
            if (principal == null || !principal.Identity.IsAuthenticated) {
                //Windows authentication failed
                return Redirect(Url.Action("Login", "Login") + "?" + Request.QueryString);
            }
            //User is validated, so let's set the authentication cookie
            FormsAuthentication.RedirectFromLoginPage(principal.Identity.Name, true);
            return null;
        }
    }
