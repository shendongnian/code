    using (var client = new Pop3Client())
    {
        try
        {
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            client.Connect("pop3.host.com", 110, false);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate("mail@host.com", "password");
            for (int i = 0; i < client.Count; i++)
            {
                        header = client.GetMessageHeaders(i);
                        header.WriteTo (Console.OpenStandardOutput ());
            }
            client.Disconnect(true);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Checking error: \n\n" + ex.Message + "\n\n\n");
        }
    }
