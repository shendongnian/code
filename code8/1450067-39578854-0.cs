    using (var client = new ImapClient(new ProtocolLogger("imap.log")))
    {
        try
        {
            client.Connect(server, this.port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.AuthenticationMechanisms.Remove("NTLM");
            client.Authenticate(user, password);
            var inbox = client.Inbox;
            inbox.Open(FolderAccess.ReadWrite);
            if (inbox.Count > 0)
            {
                var range = Enumerable.Range(0, inbox.Count).ToArray();
                inbox.AddFlags(range, MessageFlags.Deleted, false);
                inbox.Expunge();
            }
            client.Disconnect(true);
        }
        catch (AuthenticationException e)
        {
            throw e;
        }
    }
