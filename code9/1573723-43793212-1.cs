    #r "SendGrid"
    using SendGrid.Helpers.Mail;
    public static void Run(string input, out string yourExistingOutput, out Mail message)
    {
        // Do the work you already do
        message = new Mail
        {        
            Subject = "Your Subject"          
        };
        var personalization = new Personalization();
        personalization.AddTo(new Email("recipient@contoso.com"));   
        Content content = new Content
        {
            Type = "text/plain",
            Value = "Email Body"
        };
        message.AddContent(content);
        message.AddPersonalization(personalization);
    }
