    using System.Linq;
    public static class Extensions
    {
        // Extension method that works on List<User> to validate user && PW
        // - returns true if user exists and pw is ok, else false
        public static bool CheckUserPassword(this List<User> users, string user_name, string pw)
        {
            // add null checks for users, user_name and pw if you are paranoid of know your customers ;o)
            return users.Any(u => u.username == user_name && u.password == pw);
        }
    }
    public class User
    {
        public string password;
        public string username; //Unique usernames
    }
    internal class Program
    {
        private static List<User> users = new List<User> { new User { username = "admin", password = "123" } };
        static void Main(string[] args)
        {
            // use extension method like this:
            var isValid = users.CheckUserPassword("Hello","Jeha");
            Console.WriteLine($"user 'admin' with pw '8888' => {users.CheckUserPassword("admin", "8888")}");
            Console.WriteLine($"user 'admin' with pw '123' => {users.CheckUserPassword("admin", "123")}");
            Console.ReadLine();
        }
    }
