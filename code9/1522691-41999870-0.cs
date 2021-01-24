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
                var results = doc.Descendants("Row").Select(x => new {
                    limitId = (int)x.Element("LimitId"),
                    max = (int)x.Element("Max"),
                    current = (int)x.Element("Current")
                }).ToList();
            }
        }
    }
