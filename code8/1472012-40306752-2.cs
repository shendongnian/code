    using Microsoft.Owin.Security;
    using System.Web;    
    //...other usings
    public class AccountController : Controller {
    
        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login(LoginViewModel model) {
            if (ModelState.IsValid) {
                string userName = (string)Session["UserName"];
                string[] userRoles = (string[])Session["UserRoles"];
    
                ClaimsIdentity identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
    
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userName));
    
                userRoles.ToList().ForEach((role) => identity.AddClaim(new Claim(ClaimTypes.Role, role)));
    
                identity.AddClaim(new Claim(ClaimTypes.Name, userName));
    
                AuthenticationManager.SignIn(identity);
                return RedirectToAction("Success");
            } else {
                return View("Login",model);
            }
        }
    
        private IAuthenticationManager AuthenticationManager {
            get {
                return HttpContext.GetOwinContext().Authentication;
            }
        }    
    }
