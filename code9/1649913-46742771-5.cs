    public static class XElementExtensions
    {
        public static XElement LocalNameElement(this XElement parent, string localName)
        {
            return parent.Elements().FirstOrDefault(x => x.Name.LocalName == localName);
        public static IEnumerable<XElement> LocalNameElements(this XElement parent, string localName)
        {
            return parent.Elements().Where(x => x.Name.LocalName == localName);
        }
        public static string LocalNameElementValue(this XElement parent, string localName)
        {
            var element = parent.LocalNameElement(localName);
            return element == null? String.Empty : element.Value;
        }
        ...
    }
