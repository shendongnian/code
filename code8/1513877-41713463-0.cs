    [XmlType("image")]
        public class Image
        {
            [XmlElement(ElementName = "loc")]
            public string UrlLocation { get; set; }
            [XmlElement(ElementName = "caption")]
            public string Caption { get; set; }
            [XmlElement(ElementName = "title")]
            public string Title { get; set; }
            [XmlNamespaceDeclarations]
            public XmlSerializerNamespaces NameSpace
            {
                get
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("image", "http://www.google.com/schemas/sitemap-image/1.1");
                    return ns;
                }
                set { NameSpace = value; }
            }
        }
