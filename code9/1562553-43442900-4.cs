    class Program
    {
        static void Main(string[] args)
        {
            // Main logic: Login && GetHomePage
            var client = new FacebookClient();
            if (client.Login("userMail", "userPassword"))
                client.GetHomePage();
        }
    }
    // Specific client
    public class FacebookClient : CookieAwareWebClient
    {
        public bool Login(string email, string password)
        {
            var loginResult = this.Login("https://www.facebook.com/login.php",
            new NameValueCollection
            {
              { "email", email },
              { "pass", password }
            });
            return loginResult;
        }
        public void GetHomePage()
        {
            // Here's the magic.. Cookies are injected via an overriden
            var webRequest = this.GetWebRequest(new Uri("https://www.facebook.com"));
            string src = "";
            using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                src = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();
            }
        }
    }
