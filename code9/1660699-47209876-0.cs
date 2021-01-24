    static string BytesToStringConverted(byte[] bytes)
    {
        using (var stream = new MemoryStream(bytes))
        {
            using (var streamReader = new StreamReader(stream))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
