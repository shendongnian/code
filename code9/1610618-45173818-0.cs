    client.SendCompleted += (s, e) =>
    {
        client.Dispose();
        var fileattachments = msg.Attachments
                              .Select(x => x.ContentStream)
                              .OfType<FileStream>()
                              .Select(fs => fs.Name);
        
        msg.Dispose();
        foreach (var attachment in fileattachments )
        {
            File.Delete(attachment);
        }
    };
