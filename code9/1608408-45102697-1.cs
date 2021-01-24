    public void SendEmail(string toEmail, string subject, string body, bool isHtml)
    {
        var emailMessage = BuildEmailMessage(toEmail.Trim(), subject.Trim(), body, isHtml);
        
        using(var client = new SmtpClient())
        {
            _smtpClient.Send(emailMessage);
        }      
    }
    //this would be the right way to do async
    public async Task SendEmailAsync(string toEmail, string subject, string body, bool isHtml)
    {
        var emailMessage = BuildEmailMessage(toEmail.Trim(), subject.Trim(), body, isHtml);
        
        using(var client = new SmtpClient())
        {
            _smtpClient.SendMailAsync(emailMessage);
        }      
    }
    //this would be the right way to do multiple emails
    //you'd need to create an EmailModel class to contain all the details for each email (similar to MailMessage, but it would prevent your own code from taking a dependency on System.Net.Mail
    public void SendEmail(IEnumerable<EmailModel> emailModels)
    {
         
        var mailMessages = emailModels.Select(em =>  ConvertEmailModelToMailMessage(em));
        
        using(var client = new SmtpClient())
        {
            foreach(var mailMessage in mailMessages)
            {
                //you may want some error handling on the below line depending on whether you want all emails to attempt to send even if one encounters an error
                _smtpClient.Send(mailMessage);
            }
        }      
    }
    private MailMessage ConvertEmailModelToMailMessage(EmailModel emailModel)
    {
        //do conversion here
    }
