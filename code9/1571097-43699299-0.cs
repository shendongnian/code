    protected bool ProcessButton_Click(object sender, EventArgs e)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.Credentials = new NetworkCredential("myEmail@gmail.com", "password");
            //if you have double verification on gmail, then generate and write App Password
            client.EnableSsl = true;
            MailMessage message = new MailMessage(new MailAddress("myEmail@gmail.com"),
                new MailAddress(receiverEmail));
            message.Subject = "Title";
            message.Body = $"Text";
            // Attach file
            Attachment attachment;
            attachment = new Attachment("D:\list.txt");
            message.Attachments.Add(attachment);
            try
            {
                client.Send(message);
                // ALL OK
                return true;
            }
            catch
            {
                //Have problem
                return false;
            }
        }
