    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Serialization;
    namespace Oppgave3Lesson1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(StreamingEvents));
                StreamingEvents events = (StreamingEvents) serializer.Deserialize(reader);
     
            }
        }
        [XmlRoot("items")]
        public class StreamingEvents
        {
            [XmlElement("item")]
            public List<Event> Events { get; set; }
        }
        public class Event
        {
            IFormatProvider provider = CultureInfo.InvariantCulture;
            public int id { get; set; }
            public string title { get; set; }
            private DateTime _updatedAt { get; set; }
            
            public string updatedAt
            {
                get { return _updatedAt.ToString(); }
                set { _updatedAt = DateTime.ParseExact(value, "yyyy-MM-ddTHH:mm:ss+ffff", provider); }
            }
            private DateTime _startDate { get; set; }
            public string startDate
            {
                get { return _startDate.ToString(); }
                set { _startDate = DateTime.ParseExact(value, "yyyy-MM-ddTHH:mm:ss+ffff", provider); }
            }
            private DateTime _endDate { get; set; }
            public string endDate
            {
                get { return _endDate.ToString(); }
                set { _endDate = DateTime.ParseExact(value, "yyyy-MM-ddTHH:mm:ss+ffff", provider); }
            }
            public Tournament tournament { get; set; }
        }
        public class Tournament
        {
            public int id { get; set; }
            public string name { get; set; }
            public Property property { get; set; }
        }
        public class Property
        {
            public int id { get; set; }
            public string name { get; set; }
            public Sport sport { get; set; }
        }
        public class Sport
        {
            public int id { get; set; }
            public string name { get; set; }
        }
     
    }
