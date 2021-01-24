    public static partial class XmlExtensions
    {
        static XmlExtensions()
        {
            noStandardNamespaces = new XmlSerializerNamespaces();
            noStandardNamespaces.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd attributes.
        }
        readonly static XmlSerializerNamespaces noStandardNamespaces;
        internal const string RootNamespace = "XmlExtensions";
        internal const string RootName = "Root";
        public static TEnum FromXmlValue<TEnum>(this string xml) where TEnum : struct, IConvertible, IFormattable
        {
            var element = new XElement(XName.Get(RootName, RootNamespace), xml);
            return element.Deserialize<XmlExtensionsEnumWrapper<TEnum>>().Value;
        }
        public static T Deserialize<T>(this XContainer element, XmlSerializer serializer = null)
        {
            using (var reader = element.CreateReader())
            {
                object result = (serializer ?? new XmlSerializer(typeof(T))).Deserialize(reader);
                if (result is T)
                    return (T)result;
            }
            return default(T);
        }
        public static string ToXmlValue<TEnum>(this TEnum value) where TEnum : struct, IConvertible, IFormattable
        {
            var root = new XmlExtensionsEnumWrapper<TEnum> { Value = value };
            return root.SerializeToXElement().Value;
        }
        public static XElement SerializeToXElement<T>(this T obj)
        {
            return obj.SerializeToXElement(null, noStandardNamespaces); // Disable the xmlns:xsi and xmlns:xsd attributes by default.
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
    }
    [XmlRoot(XmlExtensions.RootName, Namespace = XmlExtensions.RootNamespace)]
    [XmlType(IncludeInSchema = false)]
    public class XmlExtensionsEnumWrapper<TEnum>
    {
        [XmlText]
        public TEnum Value { get; set; }
    }
