    string fromAddress = Dts.Variables["MailFromAddress"].Value.ToString();
    string recipients = Dts.Variables["MailRecipients"].Value.ToString();
    string subject = Dts.Variables["MailSubjectSuccess"].Value.ToString();
    string body = Dts.Variables["MailBodySuccess"].Value.ToString();
    
    // Replace D: in body
    string pattern = "\bD:";
    string replacement = "\d$   ";
    Regex rgx = new Regex(pattern);
    body = rgx.Replace(body, replacement);
    
    // Build my HTML message.
    myHtmlMessage = new MailMessage(fromAddress, recipients, subject, body);
