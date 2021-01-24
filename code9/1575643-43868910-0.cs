    public class Ser
    {
        [XmlIgnore]
        public List<string> List { get; set; } = new List<string> { "A", "B", "C" }; //This initializer is a must
        [XmlArray(nameof(List))]
        public string[] SerializedList
        {
            get { return List.ToArray(); }
            set { List = new List<string>(value); }
        }
    }
