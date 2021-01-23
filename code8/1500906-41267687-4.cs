    public class App
    {
        [ThreadStatic]
        private static IUser user;
        public static IUser User
        {
            get { return user; }
            set { user = value; }
        }
    }
