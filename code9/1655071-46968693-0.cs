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
                var results = doc.Descendants("characteristics").Select(x => new {
                    id = (string)x.Element("image").Attribute("id"),
                    characteristics = x.Elements("characteristic").ToList().Select(y => (string)y.Attribute("name")).ToList()
                }).ToList();
            }
        }
    }
