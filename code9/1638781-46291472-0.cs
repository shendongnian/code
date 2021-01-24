    SqlXml GetXml(string s)
    {
        var memoryStream = new MemoryStream();
        var writer = new StreamWriter(memoryStream);
        writer.Write(s);
        writer.Flush();
        memoryStream.Position = 0;
        return new SqlXml(memoryStream);
    }
