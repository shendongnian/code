    private Data Deserialize(XmlNode xmlData)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Data));
        using (var stream = new StringReader(xmlData.OuterXml))
        {
            return (Data)xmlSerializer.Deserialize(stream);
        }
    }
