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
                        var headers = client.GetMessageHeaders(i);
                        foreach (var header in headers)
                            Console.WriteLine ("{0}: {1}", header.Field, header.Value);
            }
            client.Disconnect(true);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Checking error: \n\n" + ex.Message + "\n\n\n");
        }
    }
