    public class Cube
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlArrayItem("In")
        public List<Element> In { get; set; }
        [XmlArrayItem("In")
        public List<Element> Out { get; set; }
    }
    
    public class Element
    {
        [XmlAttribute("Name")]
        public string Name { get; set, }
    }
