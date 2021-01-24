    using (var memoryStream = new MemoryStream())
    {
        blockBlob2.DownloadToStream(memoryStream);
        var length = memoryStream.Length;
        text = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
     }
