    [Serializable]
    [XmlRoot("data")]
    public class Data
    {
        [XmlArray("Pages")]
        [XmlArrayItem(ElementName = "Page", Type = typeof(Page))]
        public List<Page> Pages { get; set; }
        
    }
    [Serializable]
    public class Page
    {
        [XmlAttribute]
        public int Value { get; set; }
        //you can add additional attributes if needed.
        //just make a property and add [XmlAttribute] attrib, like this:
        //[XmlAttribute]
        //public sting SomeText { get; set; }
        //so it will be written as <Page Value="123" SomeText="abc" />
    }
	
	
