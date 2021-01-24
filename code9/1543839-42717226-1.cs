    public void email_send(Document d)
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        mail.From = new MailAddress("myemail@gmail.com");
        mail.To.Add("reciever@gmail.com");
        mail.Subject = "Test Mail - 1";
        mail.Body = "mail with attachment";
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(d, ms);
        System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
        Attachment attach = new Attachment(ms, ct);
        mail.Attachments.Add(attach);
        
        SmtpServer.Port = 587;
        SmtpServer.Credentials = new System.Net.NetworkCredential("myemail@gmail.com", "mypass");
        SmtpServer.EnableSsl = true;
        SmtpServer.Send(mail);
        writer.Flush();
        writer.Dispose();
        ms.Dispose();
    }
