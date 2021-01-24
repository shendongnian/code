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
                string header = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\" ?><gpx></gpx>";
                XDocument doc = XDocument.Parse(header);
                XElement gpx = doc.Root;
                gpx.Add(new object[] {
                    new XElement("metadata"), new XElement("time", DateTime.Now.ToString("yyyy-MM-ddthh:mm:ssz")),
                    new XElement("trk",  new object[] {
                        new XElement("name", DateTime.Now.ToString("yyyy-MM-ddthh:mm:ssz")),
                        new XElement("trksseg", new object[] {
                            new XElement("trkpt", new object[] {
                                new XAttribute("lat", 12.1795),
                                new XAttribute("lon", 12.3456),
                                new XElement("ele", -46.97),
                                new XElement("time",DateTime.Now.ToString("yyyy-MM-ddthh:mm:ssz")),
                            })
                        })
                    })
                });
            }
        }
    }
