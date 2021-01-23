    private void SaveMailAttachments(Outlook.MailItem mailItem)
    {
        Outlook.Attachments attachments = mailItem.Attachments;
        if (attachments != null && attachments.Count > 0)
        {
            for (int i = 1; i <= attachments.Count; i++)
            {
                Outlook.Attachment attachment = attachments[i];
                if (attachment.Type == Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue)
                {
                    string filename = Path.Combine(@"d:\", attachment.FileName);
                    attachment.SaveAsFile(filename);
                }
            }
        }
    }
