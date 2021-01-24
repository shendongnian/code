    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                reader.ReadLine(); //skip identification
                XDocument doc = XDocument.Load(reader);
                var results = doc.Descendants("Page").Select(x => new
                {
                    filename = (string)x.Attribute("Filename"),
                    page = (int)x.Attribute("ZonesInPage"),
                    id = (int)x.Attribute("PageID"),
                    zones = x.Elements("Zone").Select(y => new {
                        textLines = (int)y.Attribute("TextLinesInZone"),
                        ulx = (int)y.Attribute("zoneULX"),
                        uly = (int)y.Attribute("zoneULY"),
                        lrx = (int)y.Attribute("zoneLRX"),
                        lry = (int)y.Attribute("zoneLRY"),
                        textLine = y.Elements("TextLine").Select(z => new {
                            content = (string)z.Attribute("Content"),
                            id = (int)z.Attribute("TextLineID")
                        }).ToList()
                    }).ToList()
                }).ToList();
            }
        }
    }
