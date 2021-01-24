    public static class XmlSerializationHelper
    {
        public static T LoadFromXml<T>(this string xmlString)
        {
            using (StringReader reader = new StringReader(xmlString))
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
            }
        }
        public static string GetXml<T>(this T obj, XmlSerializerNamespaces ns)
        {
            using (var textWriter = new Utf8StringWriter())
            {
                var settings = new XmlWriterSettings() { Indent = true }; // For cosmetic purposes.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                    new XmlSerializer(obj.GetType()).Serialize(xmlWriter, obj, ns);
                return textWriter.ToString();
            }
        }
    }
    // http://stackoverflow.com/questions/3862063/serializing-an-object-as-utf-8-xml-in-net
    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
