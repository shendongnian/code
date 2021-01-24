    // Create the message with attachment.
    byte[] contentBytes = System.IO.File.ReadAllBytes(@"C:\test\test.png");
    string contentType = "image/png";
    MessageAttachmentsCollectionPage attachments = new MessageAttachmentsCollectionPage();
    attachments.Add(new FileAttachment
    {
        ODataType = "#microsoft.graph.fileAttachment",
        ContentBytes = contentBytes,
        ContentType = contentType,
        ContentId = "testing",
        Name = "testing.png"
    });
    Message email = new Message
    {
        Body = new ItemBody
        {
            Content = Resource.Prop_Body + guid,
            ContentType = BodyType.Text,
        },
        Subject = Resource.Prop_Subject + guid.Substring(0, 8),
        ToRecipients = recipients,
        Attachments = attachments
    };
    
    // Send the message.
    await graphClient.Me.SendMail(email, true).Request().PostAsync();
