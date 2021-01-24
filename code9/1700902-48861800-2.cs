     public partial class MvcApplication
    {
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            //For API users
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);
                if (authHeaderVal.Scheme.Equals("Basic", StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(authHeaderVal.Parameter))
                    {
                        AuthenticateUser(authHeaderVal.Parameter);
                    }
                }
            }
            //For Regular Website Users
            else
            {
                HttpCookie authCookie = request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    //Extract the forms authentication cookie
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    // If caching userData field then extract
                    var userModel = UsersBLL.DeserializeObject(authTicket.UserData);
                    var principal = new UserPrincipal(userModel);
                    SetPrincipal(principal);
                }
            }
        }
        private static bool AuthenticateUser(string credentials)
        {
            var model = UsersBLL.DecryptToken(credentials);
            if (!model.RefUser.HasValue)
            {
                return false;
            }
            SetPrincipal(new UserPrincipal(model));
            return true;
        }
        private static void SetPrincipal(UserPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }
    }    
