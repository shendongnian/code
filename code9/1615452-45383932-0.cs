    public class Global : HttpApplication
    {
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie decryptedCookie =
                Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (decryptedCookie != null)
            {
                FormsAuthenticationTicket ticket =
                    FormsAuthentication.Decrypt(decryptedCookie.Value);
                var identity = new GenericIdentity(ticket.Name);
                var roles = "Administrator,User".Split(',');
                var principal = new GenericPrincipal(identity, roles);
                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = HttpContext.Current.User;
            }
        }
    }
