    using (var client = new ImapClient ()) {
        client.Connect ("imap.gmail.com", 993, true);
        client.AuthenticationMechanisms.Remove ("XOAUTH2");
        client.Authenticate ("username", "password");
    
        client.Inbox.Open (FolderAccess.ReadOnly);
    
        var uids = client.Inbox.Search (SearchQuery.All);
    
        foreach (var uid in uids) {
            var message = client.Inbox.GetMessage (uid);
            var text = message.TextBody;
            Console.WriteLine ("This is the text/plain content:");
            Console.WriteLine ("{0}", text);
        }
    
        client.Disconnect (true);
    }
