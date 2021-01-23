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
                var results = doc.Descendants("parent").Select(x => new {
                    child1 = (string)x.Element("child1"),
                    child2 = (string)x.Element("child2"),
                    child3 = (string)x.Element("child3"),
                    child4 = (string)x.Element("child4"),
                    child5 = (string)x.Element("child5"),
                    child6 = (string)x.Element("child6")
                }).ToList();
            }
        }
    }
