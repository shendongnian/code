    public class AccountController : Controller
    {
        public void SignIn(string provider,string ReturnUrl = "/default")
        {
            // Send an OpenID Connect sign-in request.
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = ReturnUrl }, provider);
                HttpContext.Response.Cookies["provider"].Value = provider;
            }
        }
        public void SignOut()
        {
            var provider = HttpContext.Request.Cookies["provider"].Value;
            Request.Cookies.Clear();
            HttpContext.GetOwinContext().Authentication.SignOut(
                provider, CookieAuthenticationDefaults.AuthenticationType);
        }
        public void EndSession()
        {
            // If AAD sends a single sign-out message to the app, end the user's session, but don't redirect to AAD for sign out.
            HttpContext.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
        }
    }
