        string smtpAddress = "smtp.mail.yahoo.com";
        int portNumber = 587;
        bool enableSSL = true;
        string emailFrom = "mitshel@yahoo.com";
        string password = "xxxxxx!";
        List<string> emailToList = new List<string>;
        emailToList.Add("dimitris.chris@yahoo.com");
        //add as many other as you like 
        string subject = "Hello";
        string body = "Hello, I'm just writing this to say Hi!";
        using (MailMessage mail = new MailMessage())
        {
            mail.From = new MailAddress(emailFrom);
            foreach(string recipient in emailToList){
                mail.To.Add(recipient);
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            // Can set to false, if you are sending pure text.
            using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
            {
                smtp.Credentials = new NetworkCredential(emailFrom, password);
                smtp.EnableSsl = enableSSL;
                smtp.Send(mail);
             }
