    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication14
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                xml = xml.Replace("&", "&amp;");
                StringReader sReader = new StringReader(xml);
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                XmlReader reader = XmlReader.Create(sReader);
                List<Platform> platforms = new List<Platform>();
                while (!reader.EOF)
                {
                    if (reader.Name != "Platform")
                    {
                        reader.ReadToFollowing("Platform");
                    }
                    if (!reader.EOF)
                    {
                        XElement platform = (XElement)XElement.ReadFrom(reader);
                        
                        platforms.Add(new Platform()
                        {
                            tag = (int)platform.Attribute("PlatformTag"),
                            no = (int?)platform.Attribute("PlatformNo"),
                            name = (string)platform.Attribute("Name"),
                            bearingToRoad = (double?)platform.Attribute("BearingToRoad"),
                            roadName = (string)platform.Attribute("RoadName"),
                            lat = (double)platform.Element(platform.Name.Namespace + "Position").Attribute("Lat"),
                            _long = (double)platform.Element(platform.Name.Namespace + "Position").Attribute("Long")
                        });
                    }
                }
            }
        }
        public class Platform
        {
            public int tag { get; set; }
            public int? no { get; set; }
            public string name { get; set; }
            public double? bearingToRoad { get; set; }
            public string roadName { get; set; }
            public double lat { get; set; }
            public double _long { get; set; }
        }
    }
