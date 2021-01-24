    [Serializable, XmlRoot("Event")]
    public class Event
    {
        [XmlElement("Description")]
        public string Description { get; set; }
    
        [XmlElement("Reward")]
        public Resources Reward { get; set; }
    
        [XmlElement("Cost")]
        public Resources Cost { get; set; }
    
        [XmlElement("EventId")]
        public int EventId { get; set; }
    
        [XmlElement("EventType")]
        public EventType EventType { get; set; }
        [XmlIgnore]
        public string MarkUp { get; set; }
    }
    [Serializable, XmlRoot("Resources")]
    public class Resources
    {
        //Each prop can be extended to food being a Food object with expiry, etc
        [XmlElement("Food")]
        public int Food { get; set; } // 0 to cap
        [XmlElement("Happiness")]
        public int Happiness { get; set; } // 0 to 100
        [XmlElement("Energy")]
        public int Energy { get; set; } //0 to cap
        [XmlElement("ShipHp")]
        public int ShipHp { get; set; }// cap to 0
        [XmlElement("Garbage")]
        public int Garbage { get; set; } // 0 to cap
    }
    [XmlType("EventType")]
    public enum EventType
    {
        [XmlEnum("Good")]
        Good = 0,
        [XmlEnum("Bad")]
        Bad,
        [XmlEnum("Neutral")]
        Neutral
    }
    public class EventHandler : MonoBehaviour
    {
    
        List<Event> Events = new List<Event>();
        // Use this for initialization, called on script enabling
        void Start()
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<Event>));
    
                string xml = File.ReadAllText("Assets/TextResources/Events.xml");
                xml = XDocument.Parse(xml).ToString(SaveOptions.DisableFormatting);
    
                using (var stringReader = new StringReader(xml))
                {
                    using (var reader = XmlReader.Create(stringReader))
                    {
                        var result = (List<Event>)serializer.Deserialize(reader);
                        Events = result;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }
        }
    }
