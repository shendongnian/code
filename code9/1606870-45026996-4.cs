    [XmlRoot(ElementName = "result")]
    public class Result 
    {
        [XmlArray("items")]
        [XmlArrayItem("item")]
        public List<Item> items = new List<Item>();
    }
