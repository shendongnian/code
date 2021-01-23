    public static void SaveObjectToXml<T>(T obj, string file) where T : class, new()
    {
       if (string.IsNullOrWhiteSpace(file))
          throw new ArgumentNullException("File is empty");
    
       var serializer = new XmlSerializer(typeof(T));
       using (Stream fileStream = new FileStream(file, FileMode.Create))
       {
          using (XmlWriter xmlWriter = new XmlTextWriter(file, Encoding.UTF8))
          {
            serializer.Serialize(xmlWriter, obj);
          }
       }
    }
