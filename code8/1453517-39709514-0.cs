    MimeMessage messageMimeKit = MimeMessage.Load(outStream);
    messageMimeKit.From.Add(new MailboxAddress("<sender name>", "<sender email"));
    messageMimeKit.To.Add(new MailboxAddress("<recipient name>", "<recipient email>"));
    messageMimeKit.Subject = "my subject";
    
    var related = (MultipartRelated) messageMimeKit.Body;
    var body = (MimePart) related[0];
    
    // It's possible that the filename on the HTML body is confusing Outlook.
    body.FileName = null;
    
    // It's also possible that the Content-Location is confusing Outlook
    body.ContentLocation = null;
