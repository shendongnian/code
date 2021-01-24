    public class DetailSettings
    {
        public MailConfig MailConfig { get; set; }
        public string MailBaseUrl { get; set; }
        public DetailSettings()
        {
            MailConfig = new MailConfig();
        }
    }
    public class MailConfig
    {
        public Addresses Addresses { get; set; }
        public string Subject { get; set; }
    }
