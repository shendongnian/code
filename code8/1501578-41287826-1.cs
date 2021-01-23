    public class Route
    {
        public int busNumber;
        public string busType, destination;
        public DateTime departure, arrival;
        [XmlIgnore]
        public DateTime creationDate;
    }
