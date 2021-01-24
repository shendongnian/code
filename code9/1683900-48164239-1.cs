    public static class SerializationHelper
        {
            public static bool Serialize<T>(T value, out string serializedXml) where T : class
            {
                serializedXml = string.Empty;
                if (value == null)
                    return false;
    
                try
                {
                    using (var writer = new StringWriter())
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                        xmlSerializer.Serialize(writer, value);
                        serializedXml = writer.ToString();
                    }
                    return true;
                }
                catch (SerializationException)
                {
                    return false;
                }
            }
    
            public static string ToXml<T>(T value) where T : class
            {
                string result;
                Serialize(value, out result);
                return result;
            }
    
            public static T FromXml<T>(string xml) where T : class
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                var reader = new StringReader(xml);
                var obj = xmlSerializer.Deserialize(reader);
    
                return obj as T;
            }
        }
