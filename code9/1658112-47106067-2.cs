    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string INPUT_FILENAME = @"c:\temp\test.xml";
            const string OUTPUT_FILENAME = @"c:\temp\test1.xml";
            static void Main(string[] args)
            {
                Presence outPresence = new Presence()
                {
                    person = new Person()
                    {
                        status = new Status()
                        {
                            basic = "test",
                            activities = new Activities()
                            {
                            }
                        },
                    }
                };
                XmlSerializerNamespaces xmlNameSpace = new XmlSerializerNamespaces();
                xmlNameSpace.Add("pp", "urn:ietf:params:xml:ns:pidf:person");
                xmlNameSpace.Add("ep", "urn:ietf:params:xml:ns:pidf:rpid:rpid-person");
                xmlNameSpace.Add("", "urn:ietf:params:xml:ns:pidf");
                XmlSerializer serializer = new XmlSerializer(typeof(Presence), "urn:ietf:params:xml:ns:pidf");
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(OUTPUT_FILENAME, settings);
                serializer.Serialize(writer, outPresence, xmlNameSpace);
                StreamReader reader = new StreamReader(INPUT_FILENAME);
                Presence presense = (Presence)serializer.Deserialize(reader);
            }
        }
        [XmlRoot(ElementName = "presence")]
        public class Presence
        {
            [XmlElement(ElementName = "person", Namespace = "urn:ietf:params:xml:ns:pidf:person")]
            public Person person { get; set; }
        }
        [XmlRoot(ElementName = "person", Namespace = "urn:ietf:params:xml:ns:pidf:person")]
        public class Person
        {
            [XmlElement(ElementName = "status", Namespace = "urn:ietf:params:xml:ns:pidf")]
            public Status status { get; set; }
        }
        [XmlRoot(ElementName = "status", Namespace = "urn:ietf:params:xml:ns:pidf")]
        public class Status
        {
            [XmlElement("basic")]
            public string basic { get; set; }
            [XmlElement(ElementName = "activities", Namespace = "urn:ietf:params:xml:ns:pidf:rpid:rpid-person")]
            public Activities activities { get; set; }
        }
        [XmlRoot(ElementName = "activities", Namespace = "urn:ietf:params:xml:ns:pidf:rpid:rpid-person")]
        public class Activities
        {
            [XmlElement("away")]
            public string away { get; set; }
        }
    }
