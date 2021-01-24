    public static class MyExtensions
    {
        public static string FormsUserCookieName (this FormsAuthentication) {
            return FormsAuthentication.FormsCookieName + '_' + HttpContext.Current.User.Identity.Name;
        }
    }
