    public static partial class DataContractSerializerExtensions
    {
        public static string ToContractXml<T>(this T obj, DataContractSerializer serializer = null, XmlWriterSettings settings = null, DataContractResolver resolver = null)
        {
            serializer = serializer ?? new DataContractSerializer(obj == null ? typeof(T) : obj.GetType());
            using (var textWriter = new StringWriterWithEncoding((settings == null ? null : settings.Encoding) ?? Encoding.UTF8))
            {
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.WriteObject(xmlWriter, obj, resolver);
                }
                return textWriter.ToString();
            }
        }
        public static void WriteObject(this DataContractSerializer serializer, Stream stream, object obj, XmlWriterSettings settings, DataContractResolver resolver = null)
        {
            if (serializer == null || stream == null)
                throw new ArgumentNullException();
            // If settings are specified create a wrapped dictionary writer, else create a text writer directly.
            if (settings == null)
            {
                // Let caller close the stream
                using (var xmlWriter = XmlDictionaryWriter.CreateTextWriter(stream, Encoding.UTF8, false))
                {
                    serializer.WriteObject(xmlWriter, obj, resolver);
                }
            }
            else
            {
                using (var xmlWriter = XmlWriter.Create(stream, settings))
                {
                    serializer.WriteObject(xmlWriter, obj, resolver);
                }
            }
        }
        static void WriteObject(this DataContractSerializer serializer, XmlWriter xmlWriter, object obj, DataContractResolver resolver)
        {
            if (serializer == null || xmlWriter == null)
                throw new ArgumentNullException();
            using (var xmlDictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(xmlWriter))
            {
                serializer.WriteObject(xmlDictionaryWriter, obj, resolver);
            }
        }
    }
