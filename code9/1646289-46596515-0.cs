    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string soapResponse = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(soapResponse);
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                var results = root.Descendants(ns + "DataObject").Select(x => new {
                    date = (DateTime)x.Element(ns + "Date"),
                    hour = (int)x.Descendants(ns + "Hour").FirstOrDefault(),
                    time = (string)x.Descendants(ns + "Time").FirstOrDefault(),
                    runtime = (string)x.Descendants(ns + "Runtime").FirstOrDefault()
                }).ToList();
                
            }
        }
    }
