    using(MailMessage message = new MailMessage("john.smith@gmail.com"))
    {
        using(var stream = new MemoryStream())
        {
            //here I pass byte array to the stream and create an attachemnt
            message.Attachments.Add(new Attachment(stream, "name.xyz"));
            using(SmtpClient client = new SmtpClient("server.com", port))
            {
            // send message
            }
        }
    }
