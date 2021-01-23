    [Serializable]
    public class Worksheet
    {
        [XmlRoot(ElementName = "XML")]
        public class XML
        {
            [XmlArray("States")]
            public List<State> States { get; set; }
        }
        public class State
        {
            [XmlAttribute]
            public string Name { get; set; }
            [XmlArray("Neighbours")]
            [XmlArrayItem("Neighbour")]
            public List<Neighbour> Neighbours { get; set; }
        }
        public class Neighbour
        {
            [XmlAttribute]
            public string Name { get; set; }
        }
    }
    public static void Main(string[] args)
    {
        Worksheet.XML xml = PopulateListOfStates();
        XmlSerializer serializer = new XmlSerializer(typeof(Worksheet.XML));
        using (StreamWriter writer = new StreamWriter(@"C:\output.xml", false))
        {
            serializer.Serialize(writer, xml);
        }
    }
