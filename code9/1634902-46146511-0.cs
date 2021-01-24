    public class MailgunSettings
    {
        public string ApiKey { get; set; }
        public string BaseUri { get; set; }
        public string RequestUri { get; set; }
        public string From { get; set; }
        public string Smtp { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
        public int SmtpPort { get; set; }
    }
    private readonly MailgunSettings _smtpSettings;
    
    public EmailSender(IOptions<MailgunSettings> smtpSettings)
    {
        this._smtpSettings = smtpSettings.Value;
    }
