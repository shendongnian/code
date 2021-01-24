    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes("<Root1><Root2><Test><Id>5</Id></Test></Root2></Root1>")))
    using (var reader = XmlReader.Create(stream))
    {
        reader.ReadToFollowing("Test");
        var test = (Test)serializer.Deserialize(reader);
    }
