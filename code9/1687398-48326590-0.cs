    public class SessionManager : ISessionManager
        {
            #region Private Data
            private static String USER_KEY = "user";
            #endregion
            public Employee CurrentUser
            {
                get
                {
                    return (Employee)System.Web.HttpContext.Current.Session[USER_KEY];
                }
            }
            public string UserType
            {
                get { return (string) System.Web.HttpContext.Current.Session["USER_TYPE"]; }
            }
            public Int32 SessionTimeout
            {
                get
                {
                    return System.Web.HttpContext.Current.Session.Timeout;
                }
            }
            public String GetUserFullName()
            {
                if (CurrentUser != null)
                    return CurrentUser.FirstName;
                else
                    return null;
            }
            public Boolean IsUserLoggedIn
            {
                get
                {
                    if (CurrentUser != null)
                        return true;
                    else
                        return false;
                }
            }
            #region Methods
            public void AbandonSession()
            {
                for (int i = 0; i < System.Web.HttpContext.Current.Session.Count; i++)
                {
                    System.Web.HttpContext.Current.Session[i] = null;
                }
                System.Web.HttpContext.Current.Session.Abandon();
            }
            #endregion
        }
