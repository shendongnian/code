    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
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
                XmlSerializer serializer = new XmlSerializer(typeof(Sistemrent));
                Sistemrent sistemrent = (Sistemrent)serializer.Deserialize(reader);
            }
        }
     
        [XmlRoot(ElementName = "Sistemrent")]
        public class Sistemrent
        {
            [XmlElement(ElementName = "Sube")]
            public List<Sube> Sube { get; set; }
        }
        [XmlRoot(ElementName = "Sube")]
        public class Sube
        {
            [XmlElement(ElementName = "Sube_Kodu")]
            public string Sube_Kodu { get; set; }
            [XmlElement(ElementName = "Sube_Ismi")]
            public string Sube_Ismi { get; set; }
            [XmlElement(ElementName = "Kayit_ID")]
            public string Kayit_ID { get; set; }
            [XmlAttribute(AttributeName = "id")]
            public string Id { get; set; }
        }
     
    }
