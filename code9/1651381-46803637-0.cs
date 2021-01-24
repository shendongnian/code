    using(MailMessage message = new MailMessage("john.smith@gmail.com")
    using(MemoryStream stream = new MemoryStream())
    using(SmtpClient client = new SmtpClient("server.com", port))
    {
        message.Attachments.Add(new Attachment(stream, "name.xyz"))
        client.Send(messgae);
    }
