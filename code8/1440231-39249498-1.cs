    using System.Security.Claims;
    using System.Web;
    using System.Web.Mvc;
    using BusinessLogic.Services;
    using Common.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;
    namespace Test.Controllers
    {
        [AllowAnonymous]
        public class AuthController : Controller
        {
            private readonly IUsersService _usersService;
            public AuthController(IUsersService usersService)
            {
                _usersService = usersService;
            }
            [HttpGet]
            public ActionResult LogIn()
            {
                return View();
            }
            [HttpPost]
            public ActionResult LogIn(LoginModel loginModel)
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var isValid = _usersService.AuthenticateUser(loginModel);
                if (isValid)
                {
                    var identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, loginModel.Username),
                        new Claim(ClaimTypes.Name, loginModel.Username),
                    }, DefaultAuthenticationTypes.ApplicationCookie);
                    Request.GetOwinContext().Authentication.SignIn(new AuthenticationProperties() { IsPersistent = false }, identity);
                    
                    return Redirect(GetRedirectUrl(loginModel.ReturnUrl));
                }
                ModelState.AddModelError("", "Invalid credentials");
                return View();
            }
            public ActionResult LogOut()
            {
                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;
                authManager.SignOut("ApplicationCookie");
                return RedirectToAction("index", "home");
            }
            private string GetRedirectUrl(string returnUrl)
            {
                if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
                {
                    return Url.Action("index", "home");
                }
                return returnUrl;
            }
        }
    }
