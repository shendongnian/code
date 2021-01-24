    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication55
    {
        class Program
        {
            static void Main(string[] args)
            {
                string url = "http://www.bnr.ro/files/xml/years/nbrfxrates2017.xml";
                XDocument systemXml = XDocument.Load(url);
                XNamespace ns = ((XElement)systemXml.FirstNode).GetDefaultNamespace();
                DateTime date = DateTime.Parse("2017-01-05");
                var results = systemXml.Descendants(ns + "Cube")
                    .Where(x => ((DateTime)x.Attribute("date") == date))
                    .Descendants(ns + "Rate")
                    .Where(x => (string)x.Attribute("currency") == "EUR")
                    .FirstOrDefault();
                var value = (decimal)results;
     
            }
        }
       
    }
