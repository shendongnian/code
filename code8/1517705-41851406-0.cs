        void Application_PostAcquireRequestState(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            if (context.Session != null && context.User.Identity.IsAuthenticated)
            {
                bool forceLogout = false;
                if (context.Session["userLoggedInAt"] == null)
                    forceLogout = true;
                else if (!(context.Session["userLoggedInAt"] is DateTime))
                    forceLogout = true;
                else if (DateTime.UtcNow > ((DateTime)context.Session["userLoggedInAt"]).AddMinutes(30))
                    forceLogout = true;
        
                if (forceLogout)
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
        }
