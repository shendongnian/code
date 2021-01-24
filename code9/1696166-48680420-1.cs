    public static partial class XmlNodeExtensions
    {
        public static List<T> DeserializeList<T>(this XmlNodeList nodes)
        {
            return nodes.Cast<XmlNode>().Select(n => n.Deserialize<T>()).ToList();
        }
        public static T Deserialize<T>(this XmlNode node)
        {
            if (node == null)
                return default(T);
            var serializer = XmlSerializerFactory.Create(typeof(T), node.LocalName, node.NamespaceURI);
            using (var reader = new XmlNodeReader(node))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
    public static class XmlSerializerFactory
    {
        // To avoid a memory leak the serializer must be cached.
        // https://stackoverflow.com/questions/23897145/memory-leak-using-streamreader-and-xmlserializer
        // This factory taken from 
        // https://stackoverflow.com/questions/34128757/wrap-properties-with-cdata-section-xml-serialization-c-sharp/34138648#34138648
        readonly static Dictionary<Tuple<Type, string, string>, XmlSerializer> cache;
        readonly static object padlock;
        static XmlSerializerFactory()
        {
            padlock = new object();
            cache = new Dictionary<Tuple<Type, string, string>, XmlSerializer>();
        }
        public static XmlSerializer Create(Type serializedType, string rootName, string rootNamespace)
        {
            if (serializedType == null)
                throw new ArgumentNullException();
            if (rootName == null && rootNamespace == null)
                return new XmlSerializer(serializedType);
            lock (padlock)
            {
                XmlSerializer serializer;
                var key = Tuple.Create(serializedType, rootName, rootNamespace);
                if (!cache.TryGetValue(key, out serializer))
                    cache[key] = serializer = new XmlSerializer(serializedType, new XmlRootAttribute { ElementName = rootName, Namespace = rootNamespace });
                return serializer;
            }
        }
    }
