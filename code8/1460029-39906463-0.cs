        [XmlRoot("Clients")]
        public partial class Clients
        {
            [XmlElement("Client")]
            public Client noteList_ { get; set; }
        }
        [XmlRoot("Client")]
        public partial class Client
        {
            [XmlElement("Notes")]
            public Notes noteList_ { get; set; }
        }
        [XmlRoot("Notes")]
        public partial class Notes
        {
            [XmlElement("Note")]
            public List<Note> noteList_ { get; set; }
        }
        [XmlRoot("Note")]
        public class Note
        {
            [XmlText]
            public string note_ { get; set; }
        }
