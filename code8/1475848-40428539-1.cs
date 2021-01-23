    //use the constructor without parameters        
    MailMessage notificationMessage = new MailMessage()
    {
        Subject = subject,
        Body = messageBodyText,
        IsBodyHtml = false,
        SubjectEncoding = Encoding.UTF8,
        BodyEncoding = Encoding.UTF8,
    };
    //add the To address later
    notificationMessage.To.Add(toAddress);
    //from not specified, the default value from the app/web.config will be used.
