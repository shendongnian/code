    public class EmailHelper
    {
        public string To {get; set;}
        public string From {get; set;}
        public MailMessage message {get; set;}
    
        public EmailHelper(string to, string from)
        {
             To = to;
             From = from;
    
             message = new MailMessage(from, to);
        }
        
    }
