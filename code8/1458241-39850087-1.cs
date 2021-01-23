    Result result;
    using (var xmlReader = XmlReader.Create(inputStream))
    {
        xmlReader.ReadToFollowing("Response");
        xmlReader.Read(); // read CDATA tag
        using (var stringReader = new StringReader(xmlReader.Value))
        {
            var xs = new XmlSerializer(typeof(Result));
            result = (Result)xs.Deserialize(stringReader);
        }
    }
