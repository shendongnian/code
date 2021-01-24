    using (SmtpClient smtpClient = new SmtpClient("xxx", 587))
    using (MailMessage mail = new MailMessage())
    {
        smtpClient.Credentials = new System.Net.NetworkCredential("email", "pass");
        smtpClient.EnableSsl = true;
        mail.Subject = "subject";
        mail.From = new MailAddress("email", "name");
        mail.To.Add(new MailAddress("email"));
        mail.Body = "body";
        mail.IsBodyHtml = true;
        smtpClient.Send(mail);
    }
