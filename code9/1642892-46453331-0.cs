    class Program
    {
        static void Main(string[] args)
        {
            var xml = File.ReadAllText("test.xml");
            var serializer = new XmlSerializer(typeof(ItemCollection));
            using (var reader = new StringReader(xml))
            {
                var items = serializer.Deserialize(reader) as ItemCollection;
            }          
        }
    }
    [XmlRoot(ElementName = "Item")]
    public class Item
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Damage")]
        public string Damage { get; set; }
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
        [XmlElement(ElementName = "Armor")]
        public string Armor { get; set; }
    }
    [XmlRoot(ElementName = "Items")]
    public class Items
    {
        [XmlElement(ElementName = "Item")]
        public List<Item> Item { get; set; }
    }
    [XmlRoot(ElementName = "ItemCollection")]
    public class ItemCollection
    {
        [XmlElement(ElementName = "Items")]
        public Items Items { get; set; }
    }
