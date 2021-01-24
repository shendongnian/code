    private void Timerr_Tick(object sender, EventArgs e)
        {
             MailMessage mail = new MailMessage();
             SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
              mail.From = new MailAddress("email from");
             mail.To.Add("emailto");
             mail.Subject = DateTime.Now +"logfile";
             mail.Body = "mail with log file attachment";
    
             System.Net.Mail.Attachment attachment;
             attachment = new System.Net.Mail.Attachment("F:\\logfile\\logfile.txt");
             mail.Attachments.Add(attachment);
    
             SmtpServer.Port = 587;
             SmtpServer.Credentials = new System.Net.NetworkCredential("emailfrom", "password");
             SmtpServer.EnableSsl = true;
    
    SmtpServer.Send(mail);
    }
