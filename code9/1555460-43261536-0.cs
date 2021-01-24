    using System.Net.Mail;
    public static void SendMessage(string[] sendTo, string sendFrom, string subject, string messageText, string cc, string attachmentPath)
    {
        // Create a new message copying the person who sent it
        using (var message = new MailMessage(sendFrom, sendFrom, subject, messageText))
        {
            // Add each email address to send to.
            foreach (string s in sendTo)
                message.To.Add(new MailAddress(s));
            // Add cc to the message if not blank.
            if (!String.IsNullOrEmpty(cc))
                message.CC.Add(new MailAddress(cc));
            if (!String.IsNullOrEmpty(attachmentPath))
                message.Attachments.Add(new Attachment(attachmentPath));
            // Send mail through smtp server.
            using (var client = new SmtpClient("yoursmtpserverhere"))
                client.Send(message);
        }
    }
