    using(FileStream stream = File.OpenWrite(fileName))
    {
        var xmlDocument = new XDocument();
                using (var writer = xmlDocument.CreateWriter())
                {
                    var serialize = new DataContractSerializer(typeof(T));
                    serialize.WriteObject(writer, serializableObject);
                    xmlDocument.Save(stream, SaveOptions.None);
                }
    }
