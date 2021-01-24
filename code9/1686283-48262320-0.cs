    using(var message = new MailMessage(pass arguments ...))
    using(var smtpClient = new SmtpClient(_host))
    {
       smtpClient.Send(message);
    }
