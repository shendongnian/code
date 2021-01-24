    [XmlRoot("OutlTxt", Namespace = XmlNamespaces.MyNamespace)]
    public class OutlineText
    {
        [XmlIgnore]
        public string XmlStringValue { get; set; }
        [XmlAnyElement("TextOutlTxt", Namespace = XmlNamespaces.MyNamespace)]
        public XElement Value
        {
            get
            {
                var value = XmlStringValue;
                // Since the embedded XML literal might contain multiple mixed content nodes at the root level (or just be a simple string literal),
                // wrap it in a container element in the correct namespace.
                var innerXml = string.Format("<TextOutlTxt xmlns=\"{0}\">{1}</TextOutlTxt>", XmlNamespaces.MyNamespace, value);
                var element = XElement.Parse(innerXml);
                // Remove redundant xmlns attributes.  The XmlWriter will add back those that are necessary.
                foreach (var e in element.DescendantsAndSelf())
                    e.Attributes().Where(a => a.IsNamespaceDeclaration && a.Value == XmlNamespaces.MyNamespace).Remove();
                return element;
            }
            set
            {
                XmlStringValue = (value == null ? null : value.ToString());
            }
        }
    }
    public static class XmlNamespaces
    {
        public const string MyNamespace = "http://www.mynamespace/09262017";
    }
