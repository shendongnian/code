    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication16
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XNamespace ns = ((XElement)doc.FirstNode).Name.Namespace;
                var pars = doc.Descendants(ns + "par").Select(x => new {
                    lineSpacing = (int?)x.Attribute("lineSpacing"),
                    lines = x.Elements(ns + "line").Select(y => new {
                        baseline= (int)y.Attribute("baseline"),
                        l = (int)y.Attribute("l"),
                        t = (int)y.Attribute("t"),
                        r = (int)y.Attribute("r"),
                        b = (int)y.Attribute("b"),
                        formatting = (string)y.Element(ns + "formatting"),
                        lang = (string)y.Element(ns + "formatting").Attribute("lang")
                    }).ToList()
                }).ToList();
                
            }
        }
    }
