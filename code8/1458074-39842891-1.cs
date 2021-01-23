    public static T DeserializeFromXml<T>(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return default(T);
            }
            var serializer = new XmlSerializer(typeof(T));
            T entity;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                entity = (T)serializer.Deserialize(reader);
            }
            return entity;
        }
