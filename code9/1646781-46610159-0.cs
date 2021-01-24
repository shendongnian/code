    public class ObjectList
    {
        [XmlElement("Item")]
        public List<Item> Items { get; set; }
        [XmlElement("DifferentItem")]
        public List<DifferentItem> DifferentItems { get; set; }
    }
