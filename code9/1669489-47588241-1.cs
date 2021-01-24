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
                var results = doc.Descendants("PersonList").Select(x => new {
                    count = x.Elements("Person").Count(),
                    people = x.Elements("Person").Select(y => new {
                        name = (string)y.Element("Name"),
                        surname = (string)y.Element("Surname"),
                        city = (string)y.Element("City")
                    }).ToList()
                }).ToList();
            }
        }
    }
