    string url = "data:image/jpeg;base64," + Convert.ToBase64String(response2)
    
    var replyToConversation = context.MakeMessage();
    replyToConversation.Attachments = new List<Attachment>();
    replyToConversation.Attachments.Add(new Attachment()
    {
         ContentUrl = url,
         ContentType = "image/jpeg"
    });
