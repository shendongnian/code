    class Program
    {
        void Main()
        {
            // Set up defaults; lambda rather than Method group (allocs)
            ElementCreators<string>.CreateElement = (s, name, namespaceURI)
                    => ElementCreators.CreateElement(s, name, namespaceURI);
            ElementCreators<Decimal>.CreateElement = (d, name, namespaceURI)
                    => ElementCreators.CreateElement(d, name, namespaceURI);
            // Call
            XmlElement xml = ElementCreators<string>.CreateElement("hello", "name", "ns");
        }
    }
    public static class ElementCreators<T>
    {
        // Can change property get to throw KeyNotFound if null
        public static Func<T, string, string, XmlElement> CreateElement { get; set; }
    }
    public static class ElementCreators
    {
        public static XmlElement CreateElement(string s, string name, string namespaceURI)
        {
            return null;
        }
        public static XmlElement CreateElement(Decimal d, string name, string namespaceURI)
        {
            return null;
        }
    }
