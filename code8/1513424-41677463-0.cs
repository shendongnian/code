    public class Email {
        public string Body { get; set; }        
        public bool IsBodyHtml { get; set; }
        public string Subject { get; set; }
        public string[] To { get; }
        //...Any other properties you deem relevant
        //eg: public string From { get; set; }
    }
