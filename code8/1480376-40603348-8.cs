    private static string JsonToXml(string json)
    {
        var settings = new JsonSerializerSettings
        {
            Converters = { new Newtonsoft.Json.Converters.XmlNodeConverter() },
            DateParseHandling = DateParseHandling.None,
        };
        var doc = JsonConvert.DeserializeObject<XmlDocument>(json, settings);
        var xmlSettings = new XmlWriterSettings
        {
            CloseOutput = true,
            Encoding = Encoding.UTF8,
        };
        string xml;
        using (var ms = new MemoryStream())
        using (var xw = XmlWriter.Create(ms, xmlSettings))
        {
            doc.WriteTo(xw);
            xw.Flush();
            xml = xmlSettings.Encoding.GetString(ms.ToArray());
        }
        return xml;
    }
