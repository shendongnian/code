    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication59
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xmlHeader = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><polygons></polygons>";
                XDocument doc = XDocument.Parse(xmlHeader);
                XElement polygons = doc.Root;
                polygons.Add(new XElement("polygon", new object[] {
                    new XAttribute("name","polygon-1"),
                    new XElement("point", new object[] {
                        new XElement("x","38,241885"),
                        new XElement("y","5,965407")
                    })
                }));
                XElement polygon = polygons.Element("polygon");
                XElement newPoint = new XElement("point", new object[] {
                        new XElement("x","38,241885"),
                        new XElement("y","5,965407")
                    });
                polygon.Add(newPoint);
            }
        }
    }
