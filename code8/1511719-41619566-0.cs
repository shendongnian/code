    public void WriteError(Exception ex)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Exception));
        using (var memoryStream = new MemoryStream()) {
            xmlSerializer.Serialize(memoryStream, ex);
            var streamReader = new StreamReader(memoryStream);
            sql.Insert(streamReader.ReadToEnd());
        }
    }
