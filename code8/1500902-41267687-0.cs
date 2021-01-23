    public class App
    {
        public static IUser User
        {
            get { return (IUser)HttpContext.Current.Items["User"]; }
            set { HttpContext.Current.Items["User"] = value; }
        }
    }
