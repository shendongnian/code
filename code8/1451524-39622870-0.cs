    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication14
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement bookTestXMLExport = doc.Descendants().Where(x => x.Name.LocalName == "BookTestXMLExport").FirstOrDefault();
                XNamespace ns = bookTestXMLExport.GetNamespaceOfPrefix("ns1");
                var results = doc.Descendants(ns + "BookTestXMLExport").Select(x => new
                {
                    scanStatus = (string)x.Attribute("scanStatus"),
                    barCode = (string)x.Element(ns + "MachineXML").Attribute("barCode"),
                    ScanXML = x.Elements(ns + "ScanXML").Select( y => new {
                        name = (string)y.Descendants(ns + "BookXML").FirstOrDefault().Attribute("name"),
                        desc = (string)y.Descendants(ns + "BookXML").FirstOrDefault().Attribute("desc")
                    }).ToList()
                }).ToList();
            }
        }
     
    }
