    // Remove all attachments
    var attachments = mailItem.Attachments.Cast<Outlook.Attachment>().ToList();
    if (attachments.Any())
    {
        attachments.Reverse();
        attachments.ForEach(att => mailItem.Attachments.Remove(att.Index));
    }
