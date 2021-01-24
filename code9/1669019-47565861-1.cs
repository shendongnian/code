    public class BasePage : System.Web.UI.Page
    {
        C_UserSession usersession;
        public BasePage()
        {
            usersession = (C_UserSession)HttpContext.Current.Session[mySessionName];
        }
        protected override void OnInit(EventArgs e)
        {
            try
            {
                if (usersession == null)
                {
                    Response.Redirect("LoginUser.aspx");
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }
    }
