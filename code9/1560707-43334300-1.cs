    using (var client = new ImapClient ()) {
        client.Connect (Constant.GoogleImapHost, Constant.ImapPort, SecureSocketOptions.SslOnConnect);
        client.AuthenticationMechanisms.Remove (Constant.GoogleOAuth);
        client.Authenticate (Constant.GoogleUserName, Constant.GenericPassword);
    
        client.Inbox.Open (FolderAccess.ReadWrite);
        IList<UniqueId> uids = client.Inbox.Search (SearchQuery.All);
    
        foreach (UniqueId uid in uids) {
            MimeMessage message = client.Inbox.GetMessage (uid);
    
            foreach (MimeEntity attachment in message.Attachments) {
                var fileName = attachment.ContentDisposition?.FileName ?? attachment.ContentType.Name;
        
                using (var stream = File.Create (fileName)) {
                    if (attachment is MessagePart) {
                        var rfc822 = (MessagePart) attachment;
                
                        rfc822.Message.WriteTo (stream);
                    } else {
                        var part = (MimePart) attachment;
                
                        part.ContentObject.DecodeTo (stream);
                    }
                }
            }
        }
    }
