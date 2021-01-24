    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication65
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement indoorFeatures = doc.Root;
                XNamespace xsGml= indoorFeatures.GetNamespaceOfPrefix("gml");
                XNamespace ns = indoorFeatures.GetDefaultNamespace();
                var results = doc.Elements(ns + "IndoorFeatures").Select(x => new {
                    name = (string)x.Element(xsGml + "name"),
                    lowerCorner = (string)x.Descendants(xsGml +  "lowerCorner").FirstOrDefault(),
                    upperCorner = (string)x.Descendants(xsGml + "upperCorner").FirstOrDefault(),
                    primalSpaceFeatures = x.Descendants(ns + "PrimalSpaceFeatures").Select(y => new {
                        name = (string)y.Element(xsGml + "name"),
                        cellSpace = (string)y.Descendants(ns + "CellSpace").FirstOrDefault().Attribute(xsGml + "id"),
                        description = (string)y.Descendants(xsGml + "description").FirstOrDefault(),
                        cellSpaceName = (string)y.Descendants(ns + "CellSpace").FirstOrDefault().Element(xsGml + "name")
                    }).ToList()
                }).FirstOrDefault();
            }
        }
    }
