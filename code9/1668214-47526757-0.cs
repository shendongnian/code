    sing System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var resutls = doc.Descendants("State").Select(x => new {
                    cities = x.Elements("City").Select(y => new {
                        state = (string)x,
                        city = (string)y,
                        streets = y.Elements("Street").Select(z => (string)z).ToList()
                    }).ToList()
                }).SelectMany(x => x.cities).ToList();
            }
        }
    }
