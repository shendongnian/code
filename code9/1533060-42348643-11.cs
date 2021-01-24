    public class Bookings
    {
        [XmlIgnore]
        public string RootName { get; set; }
        [XmlAttribute("company")]
        public string Company { get; set; }
        [XmlElement("row")]
        public List<Booking> StudentBookings { get; set; }
    }
