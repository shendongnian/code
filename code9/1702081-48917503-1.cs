    public static class XmlNodeExtensions
    {
        public static XmlAttribute CreateAttributeWithValue(this XmlDocument doc, string name, string value)
        {
            var attr = doc.CreateAttribute(name);
            attr.Value = value;
            return attr;
        }
    }
