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
                XElement root = doc.Root;
                XElement entityType = root.Descendants().Where(x => x.Name.LocalName == "EntityType").FirstOrDefault();
                XNamespace ns = entityType.GetDefaultNamespace();
                XElement toChange = entityType.Elements(ns + "Property").Where(x => ((string)x.Attribute("Name")).Contains("Code")).FirstOrDefault();
                toChange.SetAttributeValue("StoreGeneratedPattern", "None");
            }
        }
    }
