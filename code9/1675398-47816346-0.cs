        public static T DeserializeXML<T>(string content)
        {
            if (content == null)
                return default(T);
            XmlSerializer xs = new XmlSerializer(typeof(T));
            byte[] byteArray = Encoding.ASCII.GetBytes(content);
            var contentStream = new MemoryStream(byteArray);
            var xml = xs.Deserialize(contentStream);
            return (T)xml;
        }
    
        public static string SerializeAsXML(object item)
        {
            if (item == null)
                return null;
            XmlSerializer xs = new XmlSerializer(item.GetType());
            using (var sw = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sw, new XmlWriterSettings { Indent = true }))
                {
                    xs.Serialize(writer, item);
                    return sw.ToString();
                }
            }
        }
