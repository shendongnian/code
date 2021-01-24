    public void SendEmail(string toEmail, string subject, string body, bool isHtml)
    {
        var emailMessage = BuildEmailMessage(toEmail.Trim(), subject.Trim(), body, isHtml);
        
        using(var client = new SmtpClient()
        {
            _smtpClient.Send(emailMessage);
        }      
    }
