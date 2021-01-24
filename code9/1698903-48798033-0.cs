    public static class AdifDictionaryExtensions
    {
        public static Dictionary<decimal, string> ExtractAdifDictionary(TextReader reader)
        {
            Dictionary<decimal, string> dict = new Dictionary<decimal, string>();
            using (var xmlReader = XmlReader.Create(reader))
            {
                var xd = XDocument.Load(xmlReader);
                var ns1 = (XNamespace)"http://www.clublog.org/cty/v1.0";
                var ns2 = (XNamespace)"https://clublog.org/cty/v1.0";
                dict =
                    xd
                    .Root
                    .Elements("entities", ns1, ns2).Single()
                    .Elements("entity", ns1, ns2)
                    .ToDictionary(
                        x => (decimal)x.Elements("adif", ns1, ns2).Single(),
                        x => x.Elements("name", ns1, ns2).Single().Value);
                return dict;
            }
        }
    }
    public static class XContainerExtensions
    {
        public static IEnumerable<XElement> Elements(this XContainer container, string localName, XNamespace nameSpace, params XNamespace[] additionalNamespaces)
        {
            if (container == null || localName == null)
                throw new ArgumentNullException();
            var names = new[] { nameSpace }.Concat(additionalNamespaces).Select(ns => ns + localName).ToArray();
            return container.Elements().Where(e => names.Any(n => n == e.Name));
        }
    }
