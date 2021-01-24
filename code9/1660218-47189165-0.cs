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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(XmlSerializeGpx.Gpx), "http://www.topografix.com/GPX/1/1");
                FileStream fs = new FileStream(FILENAME, FileMode.Open);
                XmlReader reader = XmlReader.Create(fs);
                XmlSerializeGpx.Gpx gpxObj = (XmlSerializeGpx.Gpx)xmlSerializer.Deserialize(reader);
            }
        }
        public class XmlSerializeGpx
        {
            [XmlRoot(ElementName = "start", Namespace = "http://www.topografix.com/GPX/1/1")]
            public class Start
            {
                public double ele { get; set; }
                public DateTime time { get; set; }
                [XmlAttribute("lat")]
                public double lat { get; set; }
                [XmlAttribute("lon")]
                public double lon { get; set; }
            }
            [XmlRoot(ElementName = "trkpt", Namespace = "http://www.topografix.com/GPX/1/1")]
            public class Trkpt
            {
                public double ele { get; set; }
                public DateTime time { get; set; }
                [XmlAttribute("lat")]
                public double lat { get; set; }
                [XmlAttribute("lon")]
                public double lon { get; set; }
            }
            [XmlRoot(ElementName = "trkseg", Namespace = "http://www.topografix.com/GPX/1/1")]
            public class Trkseg
            {
                [XmlElement("start")]
                public List<Start> start { get; set; }
                [XmlElement("trkpt")]
                public List<Trkpt> trkpt { get; set; }
            }
            [XmlRoot(ElementName = "trk", Namespace = "http://www.topografix.com/GPX/1/1")]
            public class Trk
            {
                public Trkseg trkseg { get; set; }
            }
            [XmlRoot(ElementName = "gpx", Namespace = "http://www.topografix.com/GPX/1/1")]
            public class Gpx
            {
                public Trk trk { get; set; }
            }
        }
    }
