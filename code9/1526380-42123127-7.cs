    public static class XmlNodeExtensions
    {
        public static XmlDocument AsXmlDocument<T>(this T o, XmlSerializerNamespaces ns = null, XmlSerializer serializer = null)
        {
            XmlDocument doc = new XmlDocument();
            using (XmlWriter writer = doc.CreateNavigator().AppendChild())
                new XmlSerializer(o.GetType()).Serialize(writer, o, ns ?? NoStandardXmlNamespaces());
            return doc;
        }
        public static XmlElement AsXmlElement<T>(this T o, XmlSerializerNamespaces ns = null, XmlSerializer serializer = null)
        {
            return o.AsXmlDocument(ns, serializer).DocumentElement;
        }
        public static T Deserialize<T>(this XmlElement element, XmlSerializer serializer = null)
        {
            using (var reader = new ProperXmlNodeReader(element))
                return (T)(serializer ?? new XmlSerializer(typeof(T))).Deserialize(reader);
        }
		
        /// <summary>
        /// Return an XmlSerializerNamespaces that disables the default xmlns:xsi and xmlns:xsd lines.
        /// </summary>
        /// <returns></returns>
        public static XmlSerializerNamespaces NoStandardXmlNamespaces()
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
            return ns;
        }
    }
    public class ProperXmlNodeReader : XmlNodeReader
    {
        // Bug fix from this answer https://stackoverflow.com/a/30115691/3744182
        // To http://stackoverflow.com/questions/30102275/deserialize-object-property-with-stringreader-vs-xmlnodereader
        // By https://stackoverflow.com/users/8799/nathan-baulch
        public ProperXmlNodeReader(XmlNode node) : base(node) { }
        public override string LookupNamespace(string prefix)
        {
            return NameTable.Add(base.LookupNamespace(prefix));
        }
    }
