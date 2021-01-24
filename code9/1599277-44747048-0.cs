    public void SerializeObject<T>(T serializableObject, Stream fileStream)
    {
        if (serializableObject == null) { return; }
        try
        {
            var xmlDocument = new XDocument();
            using (var writer = xmlDocument.CreateWriter())
            {
               var serialize = new DataContractSerializer(typeof(T));
               serialize.WriteObject(writer, serializableObject);
               xmlDocument.Save(fileStream, SaveOptions.None);
            }
        }
        catch (Exception ex)
        {
            //Log exception here
        }
    }
