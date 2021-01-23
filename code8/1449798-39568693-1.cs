    [XmlRoot("Dictionary")]
    public class DictionaryEx<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            XDocument document = null;
            using (XmlReader subtreeReader = reader.ReadSubtree())
            {
                document = XDocument.Load(subtreeReader);
            }
            if (document == null)
                return;
            XmlSerializer serializer = new XmlSerializer(typeof(KeyValuePairEx<TKey, TValue>));
            foreach (XElement element in document.Descendants(XName.Get("Item")))
            {
                using (XmlReader xmlReader = element.CreateReader())
                {
                    var pair = serializer.Deserialize(xmlReader) as KeyValuePairEx<TKey, TValue>;
                    this.Add(pair.Key, pair.Value);
                }
            }
            reader.ReadEndElement();
        }
        public void WriteXml(XmlWriter writer)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(KeyValuePairEx<TKey, TValue>));
            XmlSerializerNamespaces xmlNameSpaces = new XmlSerializerNamespaces();
            xmlNameSpaces.Add(string.Empty, string.Empty);
            foreach (TKey key in this.Keys)
            {
                TValue value = this[key];
                var pair = new KeyValuePairEx<TKey, TValue>(key, value);
                serializer.Serialize(writer, pair, xmlNameSpaces);
            }
        }
        [XmlRoot("Item")]
        public class KeyValuePairEx<TKey, TValue>
        {
            [XmlAttribute("Key")]
            public TKey Key;
            [XmlAttribute("Value")]
            public TValue Value;
            public KeyValuePairEx()
            {
            }
            public KeyValuePairEx(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }
    }
