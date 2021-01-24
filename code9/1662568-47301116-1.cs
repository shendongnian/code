    public static string Serialize(object obj)
    {
        var settings = new XmlWriterSettings { Indent = true };
        using (MemoryStream memoryStream = new MemoryStream())
        using (StreamReader reader = new StreamReader(memoryStream))
        {
            DataContractSerializer serializer = new DataContractSerializer(
            obj.GetType(), new Type[]
            {
                typeof(AuthenticationFault)
            });
            serializer.WriteObject(memoryStream , obj);
            memoryStream.Position = 0;
            return reader.ReadToEnd();
        }
    }
