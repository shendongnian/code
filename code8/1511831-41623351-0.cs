        public void Logout_Click(object sender, EventArgs e)
        {
            ClearSession();
            FormsAuthentication.RedirectToLoginPage();
        }
        protected void ClearSession()
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            Session.Abandon();
        }
