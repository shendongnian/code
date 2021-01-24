    public static partial class XmlSerializerExtensions
    {
        public static object DeserializePolymorphicXml(this string xml, params Type[] types)
        {
            using (var textReader = new StringReader(xml))
            {
                return textReader.DeserializePolymorphicXml(types);
            }
        }
        public static object DeserializePolymorphicXml(this TextReader textReader, params Type[] types)
        {
            if (textReader == null || types == null)
                throw new ArgumentNullException();
            var settings = new XmlReaderSettings { CloseInput = false }; // Let caller close the input.
            using (var xmlReader = XmlReader.Create(textReader, settings))
            {
                foreach (var type in types)
                {
                    var serializer = new XmlSerializer(type);
                    if (serializer.CanDeserialize(xmlReader))
                        return serializer.Deserialize(xmlReader);
                }
            }
            throw new XmlException("Invalid root type.");
        }
    }
