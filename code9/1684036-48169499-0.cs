    // Create file attachment
    Attachment ImageAttachment = new Attachment(Server.MapPath("/Images/Logo.jpg"));
    
    // Set the ContentId of the attachment, used in body HTML
    ImageAttachment.ContentId = "Logo.jpg";
     
    // Add an image as file attachment
    Msg.Attachments.Add(ImageAttachment);
