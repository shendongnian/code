    using (MailMessage mm = new MailMessage(from, emailTo))
    {
        var mailAddress = new MailAddress("address", "name for id");
        mm.From = mailAddress;
        mm.Subject = title;
        mm.Body = HttpUtility.HtmlDecode(body);
        mm.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        smtp.EnableSsl = true;
        NetworkCredential NetworkCred = new NetworkCredential(from, password);
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = NetworkCred;
        smtp.Send(mm);
    }
