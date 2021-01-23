    int fileLength = attFile.ContentLength;
    byte[] byteContent = new byte[fileLength];
    attFile.InputStream.Read(byteContent, 0, iLength);
    using (var memStream = new MemoryStream(byteContent))
    {
        System.IO.File.WriteAllBytes(server.MapPath(location + fileName), memStream .ToArray());
    }
