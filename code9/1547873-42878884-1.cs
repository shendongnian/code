    using (var client = new ImapClient ()) {
        client.Connect ("imap.gmail.com", 993, true);
        client.AuthenticationMechanisms.Remove ("XOAUTH2");
        client.Authenticate ("username", "password");
    
        client.Inbox.Open (FolderAccess.ReadOnly);
    
        // Note: the Full and All enum values don't mean what you think
        // they mean, they are aliases that match the IMAP aliases.
        // You should also note that Body and BodyStructure have
        // subtle differences and that you almost always want
        // BodyStructure and not Body.
        var items = client.Inbox.Fetch (0, -1, MessageSummaryItems.UniqueId | MessageSummaryItems.BodyStructure);
    
        foreach (var item in items) {
            if (item.TextBody != null) {
                var mime = (TextPart) client.Inbox.GetBodyPart (item.UniqueId, item.TextBody);
                var text = mime.Text;
                Console.WriteLine ("This is the text/plain content:");
                Console.WriteLine ("{0}", text);
            }
        }
    
        client.Disconnect (true);
    }
