    using (var writeStream = blob.OpenWrite())
    {
        MemoryStream memoryStream = new MemoryStream();
        using (var writer = new StreamWriter(memoryStream))
        {
            data.WriteXml(writer, XmlWriteMode.WriteSchema);
        }
    
        using (GZipStream compressionStream = new GZipStream(writeStream,
                      CompressionMode.Compress))
        {
            memoryStream.Position = 0;
            memoryStream.CopyTo(compressionStream);
        }
    }
