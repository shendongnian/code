    client.SendCompleted += (s, e) =>
    {
        client.Dispose();
        var fileattachments = msg.Attachments
                              .Select(x => x.ContentStream)
                              .OfType<FileStream>()
                              .Select(fs => fs.Name)
                              .ToArray();
        
        msg.Dispose();
        string tempPath = Path.GetTempPath();
        foreach (var attachment in fileattachments )
        {
            if(attachment.Contains(tempPath)
            {
                File.Delete(attachment);
            }
        }
    };
