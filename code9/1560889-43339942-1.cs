    public  T DeserialXmlToObject<T>(string xmlString) where T : new()
        {
            T result;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                var rdr = new StringReader(xmlString);
                result = (T)serializer.Deserialize(rdr);
            }
            catch (Exception ex)
            {                
                return default(T);
            }
            return result;
        }
