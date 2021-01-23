    public static T LoadXmlData<T>(string file) where T : class, new()
            {
                if (string.IsNullOrWhiteSpace(file))
                {
                    throw new ArgumentNullException("Filename is empty");
                }
    
                T obj = null;
    
                if (File.Exists(file))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(T));
                    using (TextReader reader = new StreamReader(file))
                    {
                       obj = deserializer.Deserialize(reader) as T;
                    }
                }
    
                return obj;
