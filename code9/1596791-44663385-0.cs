    [XmlRoot]
    [Serializable]
    public class A
    {
        [XmlElement("asd", Order = 1)]
        public string asd { get; set; }
        [XmlIgnore]
        public string[] qwe { get; set; }
        [XmlElement("nnn", Order = 2)]
        public XmlNodeWrapper [] nnn
        {
            get
            {
                if (qwe == null)
                    return null;
                var xml = new XmlDocument();
                var nodes = new List<XmlNode>(qwe.Length);
                foreach (var q in qwe)
                {
                    var nnnTag = xml.CreateNode(XmlNodeType.Element, "nnn", null);
                    nnnTag.InnerText = q;
                    nodes.Add(nnnTag);
                }
                return nodes.Select(n => (XmlNodeWrapper)n.ChildNodes).ToArray();
            }
            set
            {
                if (value == null)
                    return;
                qwe = value.Select(tag => tag.InnerText()).ToArray();
            }
        }
        [XmlElement("aaa", Order = 3)]
        public string aaa { get; set; }
    }
    [XmlType(AnonymousType = true)]
    public struct XmlNodeWrapper
    {
        public static implicit operator XmlNodeWrapper(XmlNodeList nodes)
        {
            return new XmlNodeWrapper { Nodes = nodes == null ? null : nodes.Cast<XmlNode>().ToArray() };
        }
        public static implicit operator XmlNode[](XmlNodeWrapper wrapper)
        {
            return wrapper.Nodes;
        }
        // Marking the Nodes property with both [XmlAnyElement] and [XmlText] indicates that the node array
        // may contain mixed content (I.e. both XmlElement and XmlText objects).
        // Hat tip: https://stackoverflow.com/questions/25995609/xmlserializer-node-containing-text-xml-text 
        [XmlAnyElement]
        [XmlText]
        public XmlNode[] Nodes { get; set; }
        public string InnerText()
        {
            if (Nodes == null)
                return null;
            return String.Concat(Nodes.Select(n => n.InnerText));
        }
    }
