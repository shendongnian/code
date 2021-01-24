    public class MandrillOutputService : IEmailOutputService
    {
        public bool Send(EmailMessage message, IEnumerable<TemplateContent> templateContents)
        {
            // ...
        }
    }
    public class OtherOutputService : IEmailOutputService
    {
        public bool Send(EmailMessage message, IEnumerable<TemplateContent> templateContents)
        {
            // ...
        }
    }
