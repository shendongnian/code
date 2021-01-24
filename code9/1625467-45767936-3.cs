    public static class XmlKeyValueListHelper
    {
        const string RootLocalName = "Root";
        public static XElement [] SerializeToXElements<T>(this IDictionary<string, T> dictionary, XNamespace ns)
        {
            if (dictionary == null)
                return null;
            ns = ns ?? "";
            var serializer = XmlSerializerFactory.Create(typeof(T), RootLocalName, ns.NamespaceName);
            var array = dictionary
                .Select(p => new { p.Key, Value = p.Value.SerializeToXElement(serializer, true) })
                // Fix name and remove redundant xmlns= attributes.  XmlWriter will add them back if needed.
                .Select(p => new XElement(ns + p.Key, p.Value.Attributes().Where(a => !a.IsNamespaceDeclaration), p.Value.Elements()))
                .ToArray();
            return array;
        }
        public static IEnumerable<KeyValuePair<string, T>> DeserializeFromXElements<T>(this IEnumerable<XElement> elements)
        {
            if (elements == null)
                yield break;
            XmlSerializer serializer = null;
            XNamespace ns = null;
            foreach (var element in elements)
            {
                if (serializer == null || element.Name.Namespace != ns)
                {
                    ns = element.Name.Namespace;
                    serializer = XmlSerializerFactory.Create(typeof(T), RootLocalName, ns.NamespaceName);
                }
                var elementToDeserialize = new XElement(ns + RootLocalName, element.Attributes(), element.Elements());
                yield return new KeyValuePair<string, T>(element.Name.LocalName, elementToDeserialize.Deserialize<T>(serializer));
            }
        }
        public static XmlSerializerNamespaces NoStandardXmlNamespaces()
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
            return ns;
        }
        public static XElement SerializeToXElement<T>(this T obj)
        {
            return obj.SerializeToXElement(null, NoStandardXmlNamespaces());
        }
        public static XElement SerializeToXElement<T>(this T obj, XmlSerializerNamespaces ns)
        {
            return obj.SerializeToXElement(null, ns);
        }
        public static XElement SerializeToXElement<T>(this T obj, XmlSerializer serializer, bool omitStandardNamespaces)
        {
            return obj.SerializeToXElement(serializer, (omitStandardNamespaces ? NoStandardXmlNamespaces() : null));
        }
        public static XElement SerializeToXElement<T>(this T obj, XmlSerializer serializer, XmlSerializerNamespaces ns)
        {
            var doc = new XDocument();
            using (var writer = doc.CreateWriter())
                (serializer ?? new XmlSerializer(obj.GetType())).Serialize(writer, obj, ns);
            var element = doc.Root;
            if (element != null)
                element.Remove();
            return element;
        }
        public static T Deserialize<T>(this XContainer element, XmlSerializer serializer)
        {
            using (var reader = element.CreateReader())
            {
                object result = (serializer ?? new XmlSerializer(typeof(T))).Deserialize(reader);
                return (T)result;
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
