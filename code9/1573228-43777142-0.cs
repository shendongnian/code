    public class EmailConfig
    {
        public EmailConfig()
        {
            this.AmazonClient = new AmazonSimpleEmailServiceClient(this.amazonUserName, this.amazonPassword);
        }
        protected MailMessage MailMessage { get; set; } = new MailMessage(); //Fields must be declared with private access. Use properties to expose fields
        protected RawMessage RawMessage { get; set; } = new RawMessage();  //Fields must be declared with private access. Use properties to expose fields
        protected SendRawEmailRequest Request { get; set; } = new SendRawEmailRequest(); //Fields must be declared with private access. Use properties to expose fields
        protected List<string> MailNotifications { get; set; } = new List<string>(); //Fields must be declared with private access. Use properties to expose fields
        protected List<string> AdditionalNotifications { get; set; } = new List<string>(); //Fields must be declared with private access. Use properties to expose fields
        protected List<string> AdditionalNotificationsinBCC { get; set; } = new List<string>(); //Fields must be declared with private access. Use properties to expose fields
        private string amazonUserName = "user name";
        private string amazonPassword = "Password";
        public AmazonSimpleEmailServiceClient AmazonClient { get; protected set; }
    }
