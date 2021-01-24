    try
    {
        var dot = Request.QueryString["dot"]?.ToLower() ?? string.Empty;
        var dep = Request.QueryString["dep"]?.ToLower() ?? string.Empty;
        var fdny = Request.QueryString["fdny"]?.ToLower() ?? string.Empty;
        var hro = Request.QueryString["hro"]?.ToLower() ?? string.Empty;
    
        //Putting if block of more specific condition check first.
        if (dot == "gcl36" && (fdny == "rejected" || hro == "rejected"))
        {
            mail.To.Add(new MailAddress("receiver@domain.org"));
            mail.From = new MailAddress("sysadmin@domain.org", "DONOTREPLY");
            mail.Subject = "The Subject ";
            mail.IsBodyHtml = true;
            mail.Body = "testing testing testing";
            smtpClient.Send(mail);
        }
        else if (dot == "rejected" || dep == "rejected" || fdny == "rejected")
        {
            mail.To.Add(new MailAddress("receiver@domain.org"));
            mail.From = new MailAddress("sysadmin@domain.org", "DONOTREPLY");
            mail.Subject = "The Subjectt";
            mail.IsBodyHtml = true;
            mail.Body = "testing testing testing";
            smtpClient.Send(mail);
        }
    }
    catch (Exception ex)
    {
        return;
    }
