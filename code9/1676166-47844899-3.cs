     protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null && !authTicket.Expired)
                {
                    var roles = authTicket.UserData.Split(',');//fill it from database and it could be better to use cache mechanism for performance concern
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), roles);
                }
            }
        }
