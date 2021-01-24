    foreach (var attachment in mail.Attachments.Where(a => a is FileAttachment && a.ContentType == "image/jpeg"))
    {
        Console.WriteLine(attachment.Name);
        FileAttachment fileAttachment = attachment as FileAttachment;
        string imagename = s + "-" + System.DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".jpg";
        /* download attachment to folder */
        fileAttachment.Load(imageLocation + "\\Images\\" + imagename);
    }
