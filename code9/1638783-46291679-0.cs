    public static SqlXml GetXml(string s)
    {
        var encoding = new UTF8Encoding();
        var memoryStream = new MemoryStream(encoding.GetBytes(s));
        return new SqlXml(memoryStream);
    }
