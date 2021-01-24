    public class BasePage : System.Web.UI.Page
    {
        C_UserSession usersession;
        public BasePage()
        {
            usersession = new C_UserSession();
        }
        protected override void OnInit(EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(usersession.UserName) || string.IsNullOrEmpty(usersession.Role))
                {
                }
            }
        }
    }
