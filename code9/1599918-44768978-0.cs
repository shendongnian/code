    [XmlType("Group")]
    public class PageGroup
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    
        [XmlElement("PageName")]
        public List<Page> Pages { get; set; }
    
        public PageGroup()
        {
            Pages = new List<Page>();
        }
    }
