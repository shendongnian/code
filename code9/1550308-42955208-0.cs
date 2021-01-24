    [SqlFunction(Name = "ReturnXml")]
    public static SqlXml ReturnXml()
    {
        MemoryStream ms = new MemoryStream();
        // fill your memory stream
        return new SqlXml(ms);
    }
