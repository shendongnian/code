    public static void email_send()
    {
        using (MailMessage mail = new MailMessage())
        {
            var dataToSend = push_notify();
            
            mail.From = new MailAddress("someemail@somedomain.com");
            mail.To.Add("somereceiver@somedomain.com");
            mail.Subject = "Hello World";
            mail.Body = dataToSend.Join(", ");
            mail.IsBodyHtml = true;
            mail.Attachments.Add(new Attachment("C:\\Users\\vijay\\Downloads\\dancdan.xml"));
            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential("someemail@somedomain.com", "somepassword");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
        }
    }
