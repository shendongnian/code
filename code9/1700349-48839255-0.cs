    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                SpawnPoint.points = doc.Descendants("SpawnPoint").Select(x => new SpawnPoint() {
                    x = x.Descendants("X").Select(y => (double)y).FirstOrDefault(),
                    y = x.Descendants("Y").Select(y => (double)y).FirstOrDefault(),
                    z = x.Descendants("Z").Select(y => (double)y).FirstOrDefault(),
                    heading = (double)x.Element("Heading")
                }).ToList();
            }
        }
        public class SpawnPoint
        {
            public static List<SpawnPoint> points = new List<SpawnPoint>();
            public double x { get; set; }
            public double y { get; set; }
            public double z { get; set; }
            public double heading { get; set; }
        }
    }
