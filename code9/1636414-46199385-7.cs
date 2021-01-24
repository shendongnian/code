        public static T SerializeXMLString<T>(string xmlstring, string schemaPath)
        {
            var serializer = new XmlSerializer(typeof(T));
            TextReader reader = new StringReader(xmlstring);
            if (!string.IsNullOrWhiteSpace(schemaPath))
                ValidateXmlDocument(reader, schemaPath);
            return (T)serializer.Deserialize(new StringReader(xmlstring));
        }
