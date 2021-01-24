    public class Bar
    {
        public string Name { get; set; }
        [System.Xml.Serialization.XmlElement]
        public List<AnimalsEnum> Foo { get; set; }
        public enum AnimalsEnum { Tiger, Elephant, Monkey }
    }
