    [XmlRoot(ElementName = "result")]
    public class Result 
    {
        [XmlArray("items")]
        [XmlArrayItems("item")]
        public List<Item> items = new List<Item>();
    }
