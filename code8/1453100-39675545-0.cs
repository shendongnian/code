    void sendMail(string invoiceNumber)
    {
        try
        {
            MailMessage mail = new MailMessage();
                mail.To.Add("recevermailid");
                mail.From = new MailAddress("sender id");
                mail.Subject = "Confirmation";
                string Body = "your message body";
                mail.Body = Body; 
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("sender email", "seneder email password");// Enter seders User name and password
                smtp.EnableSsl = true;
                smtp.Send(mail);
                
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
