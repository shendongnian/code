    MailMessage mail = new MailMessage();
    mail.IsBodyHtml = true;                   
    AlternateView alterView = ContentToAlternateView(bodyHtml);
    mail.AlternateViews.Add(alterView);
    //more settings
    //...
    //////////////
    SmtpClient smtp = new SmtpClient(Host, Port) { EnableSsl = false };
    smtp.Send(mail);
