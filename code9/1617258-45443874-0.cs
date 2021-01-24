    public static string Serialize(T obj, Type toType)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        using (StreamReader reader = new StreamReader(memoryStream))
        {
            DataContractSerializer serializer = new DataContractSerializer(toType);
            serializer.WriteObject(memoryStream, obj);
            memoryStream.Position = 0;
            return reader.ReadToEnd();
        }
    }
