    public class Physical
    {
        [XmlElement("Capacity", typeof(int))]
        [XmlElement("Class", typeof(string))]
        public object[] Items { get; set; }
    }
