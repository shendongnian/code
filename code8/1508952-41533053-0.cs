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
                StreamReader stream = new StreamReader(FILENAME, Encoding.UTF8);
                XDocument xdoc = XDocument.Load(stream);
                XElement root = xdoc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                
                List<XElement> responseXml = xdoc.Descendants(ns + "ResourceSets").ToList();
                List<XElement> locations = xdoc.Descendants(ns + "GeocodePoint").Elements(ns + "Latitude").ToList();
            }
        }
    }
