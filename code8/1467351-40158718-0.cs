    public class hello
    {
        public void eggroll()
        {
            MailAddress senderAddress = new MailAddress("example@gmail.com");
            MailAddress receiverAddress = new MailAddress("example@gmail.com");
            using (MailMessage mail = new MailMessage(senderAddress, receiverAddress))
            {
                System.Net.Mail.Attachment attachment;
                attachment = new     System.Net.Mail.Attachment("C:\\Users\\example\\Desktop\\file.txt");
                mail.Attachments.Add(attachment);
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(
                    "example@gmail.com", "example");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
        }
    }
