    Message message = new Message(fileToClean.InputFileName);
    var attachmentList = new List<Attachment>();
    // First check all attachments, and add the clean ones to the attachment list
    foreach (BodyPart bodyPart in message.BodyParts)
    {
        if ((bodyPart.ContentDisposition != null) &&
            (bodyPart.ContentDisposition.Type == ContentDispositionType.Attachment))
        {
            foreach (Attachment attachment in message.GetAttachments())
            {
                if (attachment.GetFileName() == bodyPart.ContentDisposition.Parameters[0].Value)
                {
                    if (IsClean(attachment, fileToClean))
                    {
                        attachmentList.Add(attachment);
                    }
                    break;
                }
            }
        }
    }
    // Remove all attachements
    message.BodyParts.RemoveAll(bp =>
                           (bp.ContentDisposition != null) &&
                           (bp.ContentDisposition.Type == 
    ContentDispositionType.Attachment));
    // Attach Cleaned attachments
    foreach (Attachment attachment in attachmentList)
    {
        message.BodyParts.Add(new BodyPart(attachment));
    }
