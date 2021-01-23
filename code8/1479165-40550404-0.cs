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
    
                var writer = new System.Xml.Serialization.XmlSerializer(typeof(T));
    
                using (var file = new StreamWriter(filePath))
                {
                    writer.Serialize(file, entity);
                    return true;
    
                }
            }
    }
