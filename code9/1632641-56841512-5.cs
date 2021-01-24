    namespace AppSettingsTest
    {
        public class AppSettings
        {
            public Email Email { get; set; }
        }
    
        public class Email
        {
            public string Host { get; set; }
            public int Port { get; set; }
            public string From { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
