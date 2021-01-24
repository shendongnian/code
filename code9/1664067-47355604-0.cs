     public static class StringExtensions
    {
        public static string Encrypt(this string plainText)
        {
            // Replace with your encryption impl
            return plainText;
        }
        public static string Decrypt(this string hiddenText)
        {
            // Replace with your decryption impl 
            return hiddenText;
        }
    }
    public static class SessionExtensions
    {
        public static void Set<T>(this HttpSessionState sessionState, string key, T value)
        {
            sessionState[key] = value;
        }
        public static T Get<T>(this HttpSessionState sessionState, string key) where T : class
        {
            return (T)sessionState[key];
        }
    }
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Set("UserName", "something");
            Session.Set("Password", "something".Encrypt());
            var username = Session.Get<string>("UserName");
            var password = Session.Get<string>("Password").Decrypt();
            var savedUser = $"{username}{password}";
            var currentUser = $"somethingsomething";
            if (currentUser.Equals(savedUser, StringComparison.InvariantCultureIgnoreCase))
            {
            }
            else
            {
            }
        }
    }
