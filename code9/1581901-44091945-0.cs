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
                var results = doc.Descendants("Config").Select(x => new {
                    name = (string)x.Element("Type"),
                    type = x.Element("Inputs").Elements().Select(y => new
                    {
                        id = y.Name.LocalName,
                        name = (string)y.Elements().First(),
                        input = (int)y.Elements().Last()
                    }).ToList()
                }).ToList();
            }
        }
    }
