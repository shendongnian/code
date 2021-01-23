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
                var results = doc.Descendants("lib").Select(x => new {
                    id = (string)x.Attribute("id"),
                    revision = (int)x.Attribute("revision"),
                    parts = x.Elements("part").Select(y => new {
                        id = (int)y.Attribute("id"),
                        type = (string)y.Attribute("type")
                    }).ToList()
                }).ToList();
            }
        }
    }
