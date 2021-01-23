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
                XElement dataset = (XElement)doc.FirstNode;
                XNamespace ns = dataset.Name.Namespace;
                var results = doc.Descendants(ns + "row").Select(x => new {
                    firstAddr = (string)x.Elements(ns + "value").FirstOrDefault(),
                    secondAddr = (string)x.Elements(ns + "value").Skip(1).FirstOrDefault(),
                    dob = (DateTime)x.Elements(ns + "value").Skip(2).FirstOrDefault()
                }).ToList();
            }
        }
    }
