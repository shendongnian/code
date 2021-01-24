    foreach (EmailMessage message in findResults)
    {
        EmailMessage.Bind(service, new ItemId(message.Id.ToString()), new PropertySet(BasePropertySet.IdOnly, ItemSchema.Attachments));
        // Iterate through the attachments collection and load each attachment.
        foreach (Attachment attachment in message.Attachments)
        {
            if (attachment is FileAttachment)
            {
                // Load the file attachment into memory and print out its file name.
                fileAttachment.Load();
                Console.WriteLine("Attachment name: " + fileAttachment.Name);
                // Load attachment contents into a file.
                fileAttachment.Load("C:\\temp\\" + fileAttachment.Name);
                // Stream attachment contents into a file.
                FileStream theStream = new FileStream("C:\\temp\\Stream_" + fileAttachment.Name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                fileAttachment.Load(theStream);
                theStream.Close();
                theStream.Dispose();
            }
            else // Attachment is an item attachment.
            {
                // Load attachment into memory and write out the subject.
                ItemAttachment itemAttachment = attachment as ItemAttachment;
                itemAttachment.Load();
                Console.WriteLine("Subject: " + itemAttachment.Item.Subject);
            }
        }
    }
