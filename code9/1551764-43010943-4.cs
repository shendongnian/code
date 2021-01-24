    public class MandrillOutputService : IEmailOutputService
    {
        public MandrillOutputService()
        {
        }
        public bool Send(EmailMessage message, IEnumerable<TemplateContent> templateContents)
        {
            if (message == null)
                return false;
   
            return true;
        }
    }
    public class OtherOutputService : IEmailOutputService
    {
        public OtherOutputService()
        {
        }
        public bool Send(EmailMessage message, IEnumerable<TemplateContent> templateContents)
        {
            return true;
        }
    }
