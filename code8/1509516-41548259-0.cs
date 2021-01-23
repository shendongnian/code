    [XmlRoot("command")]
    public class Command
    {
        [XmlElement("itemlist")]
        public ItemList ItemList { get; set; }
    }
    
    public class ItemList
    {
        [XmlAttribute("totalsize")]
        public int TotalSize { get; set; }
    
        [XmlElement("item")]
        public List<Item> Items { get; set; }
    }
    
    public class Item
    {
        [XmlAttribute("itemid")]
        public string ItemID { get; set; }
    }
