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
                var results = doc.Descendants("Chart1_CategoryGroup").Where(x => x.Element("Value").Attribute("Y") != null).Select(x => new {
                    label = (DateTime)x.Attribute("Label"),
                    y = (double)x.Element("Value").Attribute("Y"),
                    x = (DateTime)x.Element("Value").Attribute("X")
                }).ToList();
            }
        }
    }
