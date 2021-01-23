    public static class XmlExtensions
    {
    
    
            public static bool EntityToXml<T>(this T entity, string filePath)
            {
    
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new ArgumentNullException(nameof(filePath));
                }
    
                var dir = Path.GetDirectoryName(filePath);
    
                if (string.IsNullOrEmpty(dir))
                {
                    throw new ArgumentNullException(nameof(filePath));
                }
    
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
    
                var serializer= new System.Xml.Serialization.XmlSerializer(typeof(T));
    
                using (var stream = new StreamWriter(filePath))
                {
                    serializer.Serialize(stream , entity);
                    return true;
    
                }
            }
    }
