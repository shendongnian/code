    using System.IO;
    using System.IO.Compression;
    
    string zipPath = @"./html-files.ZIP";
    using (ZipArchive archive = ZipFile.OpenRead (zipPath)) {
        ZipArchiveEntry entry = archive.GetEntry ("msg.html");
        var stream = new MemoryStream ();
    
        // extract the content from the zip archive entry
        using (var content = entry.Open ())
            content.CopyTo (stream);
    
        // rewind the stream
        stream.Position = 0;
    
        bodyBuilder.Attachments.Add ("msg.html", stream);
    }
