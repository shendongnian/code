    class XmlAttributeParser
    {
        IEnumerable<XAttribute> attributes;
    
        public XmlAttributeParser(string xml)
        {
            attributes = XElement.Parse(xml)
                .DescendantsAndSelf()
                .SelectMany(e => e.Attributes());
        }
    
        public T GetAttribute<T>(string name)
        {
            return (T)TypeDescriptor.GetConverter(typeof(T))
                .ConvertFromString(attributes.First(a => a.Name == name).Value);
        }
    }
