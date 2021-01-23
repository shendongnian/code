    public class User
    {
        public static string SerializeUser(User u = null)
        {
            if (u != null)
                return u.SerializeUser();
            else
                return "something"; //default(User).SerializeUser();?
        }
    }
    
    public static class UserExtensions
    {
        public static string SerializeUser(this User u)
        {
            //return however you serialize your user.
        }
    }
