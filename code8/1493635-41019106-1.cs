    [XmlRoot("result")]
    public class Result
    {
        public Stats Stats {get; set;}
        [XmlArray("items")]
        [XmlArrayItem("item")] 
        public List<Item> Items { get; set; }
    }
