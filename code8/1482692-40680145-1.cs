    using (SmtpClient client = new SmtpClient())
    {
        client.Host = "mail.fakedomain.nl";
        client.Port = 25;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential("fake@fakedomain.nl", "abcd123");
    }
