        public static string SerializeObject(this object obj)
        {
            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.GetEncoding("ISO-8859-1"),
                NewLineChars = Environment.NewLine,
                ConformanceLevel = ConformanceLevel.Auto,
                OmitXmlDeclaration = true,
                WriteEndDocumentOnClose = true,
                Indent = true
            };           
            var stream = new StringBuilder();
            using (var writer = XmlWriter.Create(stream, settings))
            {
                var xmlSerializer = new XmlSerializer(obj.GetType());
                var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                xmlSerializer.Serialize(new XmlWriterEE(writer), obj, namespaces);                
            }
            return stream.ToString();
        }
