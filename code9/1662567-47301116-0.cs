    public static string Serialize(object obj)
    {
        var settings = new XmlWriterSettings { Indent = true };
        using (MemoryStream memoryStream = new MemoryStream())
        using (StreamReader reader = new StreamReader(memoryStream))
        using (var writer = XmlWriter.Create(memoryStream, settings))
        {
            DataContractSerializer serializer = new DataContractSerializer(
            obj.GetType(), new Type[]
            {
                typeof(AuthenticationFault)
            });
            serializer.WriteObject(writer, obj);
            memoryStream.Position = 0;
            return reader.ReadToEnd();
        }
    }
