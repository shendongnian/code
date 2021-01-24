    [Bind(Exclude="EmailAccounts")]
    public class EmailTemplateViewModel
    {
     	public List<EmailAccount> EmailAccounts { get; set; }
        public EmailTemplate EmailTemplate { get; set; }
        [Display(Name = "Email Account")]
        public int EmailAccountId { get; set; }
    }
    [Bind(Exclude="Property1,Property2")]
    public class EmailTemplate
    {
        public string Property1 {get;set;}
        public string Property2 {get;set;}
        public string Property3 {get;set;}
    }
