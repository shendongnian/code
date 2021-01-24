    // Assign your strings into variables to make your code cleaner:
    string fromAddress = Dts.Variables["MailFromAddress"].Value.ToString();
    string recipients = Dts.Variables["MailRecipients"].Value.ToString();
    string subject = Dts.Variables["MailSubjectSuccess"].Value.ToString();
    string body = Dts.Variables["MailBodySuccess"].Value.ToString();
    
    // Replace D: in body
    string pattern = "\\bD:"; // The backslash b is for word boundaries. This means "D:" will have to appear after a white space or non-Alphanumeric.
    string replacement = "\\d$   "; // What we're replacing with.
    Regex rgx = new Regex(pattern);
    body = rgx.Replace(body, replacement);
    
    // Build my HTML message.
    myHtmlMessage = new MailMessage(fromAddress, recipients, subject, body);
