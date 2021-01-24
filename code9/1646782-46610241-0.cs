    public class Program
    {
        public static void Main()
        {
            var serializer = new XmlSerializer(typeof(ObjectList));
            var xml = "<ObjectList><Item Attr1=\"1\" /><Item Attr1=\"2\" /><DifferentItem Attr2=\"5\" /></ObjectList>";
    
            using (var reader = new StringReader(xml))
            {
                var schedule = (ObjectList)serializer.Deserialize(reader);
            }
        }
    
        [XmlRoot("ObjectList")]
        public class ObjectList
        {
            [XmlElement("Item")]
            public List<Item> Items { get; set; }
    
            [XmlElement("DifferentItem")]
            public List<DifferentItem> DifferentItems { get; set; }
        }
    
        public class Item
        {
            [XmlAttribute("Attr1")]
            public string Attr1 { get; set; }
        }
    
    
        public class DifferentItem
        {
            [XmlAttribute("Attr2")]
            public string Attr2 { get; set; }
        }
    }
