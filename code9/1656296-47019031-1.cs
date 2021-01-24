    using (var client = new ImapClient ()) {
        client.Connect ("imap.mail-server.com", 993, SecureSocketOptions.SslOnConnect);
        client.Authenticate ("username", "password");
    
        // if you don't care about modifying message flags or deleting
        // messages, you can open the INBOX in read-only mode...
        client.Inbox.Open (FolderAccess.ReadOnly);
    
        // search for messages sent since a particular date
        var uids = client.Inbox.Search (SearchQuery.SentAfter (date));
    
        // using the uids of the matching messages, fetch the BODYSTRUCTUREs
        // of each message so that we can figure out which MIME parts to
        // download individually.
        foreach (var item in client.Inbox.Fetch (uids, MessageSummaryItems.BodyStructure MessageSummaryItems.UniqueId)) {
            foreach (var attachment in item.Attachments.OfType<BodyPartBasic> ()) {
                var part = (MimePart) client.Inbox.GetBodyPart (item.UniqueId, attachment);
    
                using (var stream = File.Create (part.FileName))
                    part.ContentObject.WriteTo (stream);
            }
        }
    }
