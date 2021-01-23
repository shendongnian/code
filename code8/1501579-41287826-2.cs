    public class Route
    {
        public int busNumber;
        public string busType, destination;
        public DateTime departure, arrival;
        [XmlIgnore]
        public DateTime creationDate;
        // how to ignore a property
        private int ignored;
        [XmlIgnore]
        public int Ignored { get { return ignored; } set { ignored = value; } }
    }
