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
                string inputLine = "";
                while((inputLine = reader.ReadLine()) != null)
                {
                    if (inputLine.Contains("<!--"))
                         break;
                }
                if (!reader.EndOfStream)
                {
                    XDocument doc = XDocument.Load(reader);
                    var results = doc.Descendants("isopackager").Select(x => new
                    {
                        isofields = x.Elements("isofield").Select(y => new
                        {
                            _class = (string)y.Attribute("name"),
                            name = (string)y.Attribute("class"),
                            length = (int)y.Attribute("length"),
                            id = (int)y.Attribute("id")
                        }).ToList(),
                        isofieldpackager = x.Elements("isofieldpackager").Select(y => new
                        {
                            _class = (string)y.Attribute("name"),
                            name = (string)y.Attribute("class"),
                            length = (int)y.Attribute("length"),
                            id = (int)y.Attribute("id"),
                            packager = (string)y.Attribute("packager"),
                            isofields = x.Elements("isofield").Select(z => new
                            {
                                _class = (string)z.Attribute("name"),
                                name = (string)z.Attribute("class"),
                                length = (int)z.Attribute("length"),
                                id = (int)z.Attribute("id")
                            }).ToList()
                        }).FirstOrDefault(),
                    }).FirstOrDefault();
                }
            }
        }
    }
