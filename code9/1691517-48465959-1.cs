    [XmlRoot("items")]
    public class StreamingEvents
    {
        [XmlElement("item")]
        public List<Event> Events { get; set; }
    }
 
