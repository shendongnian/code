    foreach (Item i in findResults.Items)
    {
        foreach(FileAttachment attachment in i.Attachments)
        {
            attachment.Load(@"\\FilePathDirectory\" + attachment.FileName);
        }
    
        i.Move(processedFolderId);
    }
