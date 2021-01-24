    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication13
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> shipTo = doc.Descendants("shipto").ToList();
                foreach (XElement ship in shipTo)
                {
                    ship.Element("name").ReplaceWith(new XElement("FullName", (string)ship.Element("name")));
                    ship.Element("address").ReplaceWith(new XElement("FirstAddress", (string)ship.Element("address")));
                    ship.Element("city").ReplaceWith(new XElement("homeTown", (string)ship.Element("city")));
                    ship.Element("country").ReplaceWith(new XElement("HomeLand", (string)ship.Element("country")));
                }
            }
            
        }
     
    }
