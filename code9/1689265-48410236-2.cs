    public static partial class XmlSerializationHelper
    {
        public static string GetXml<T>(this T obj, XmlSerializer serializer = null, XmlSerializerNamespaces ns = null)
        {
            ns = ns ?? obj.GetXmlNamespaceDeclarations();
            using (var textWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings() { Indent = true }; // For cosmetic purposes.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                    (serializer ?? new XmlSerializer(obj.GetType())).Serialize(xmlWriter, obj, ns);
                return textWriter.ToString();
            }
        }
        
        public static XmlSerializerNamespaces GetXmlNamespaceDeclarations<T>(this T obj)
        {
            if (obj == null)
                return null;
            var type = obj.GetType();
            return type.GetFields()
                .Where(f => Attribute.IsDefined(f, typeof(XmlNamespaceDeclarationsAttribute)))
                .Select(f => f.GetValue(obj))
                .Concat(type.GetProperties()
                    .Where(p => Attribute.IsDefined(p, typeof(XmlNamespaceDeclarationsAttribute)))
                    .Select(p => p.GetValue(obj, null)))
                .OfType<XmlSerializerNamespaces>()
                .SingleOrDefault();
        }
		
		public static XmlSerializerNamespaces With(this XmlSerializerNamespaces xmlns, string prefix, string ns)
		{
			if (xmlns == null)
				throw new ArgumentNullException();
			xmlns.Add(prefix, ns);
			return xmlns;
		}		
    }
