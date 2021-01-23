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
            static void Main(string[] args)
            {
                string xml =
                    "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                    "<alto xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"" +
                      " xmlns=\"http://www.loc.gov/standards/alto/ns-v3#\"" +
                      " xsi:schemaLocation=\"http://www.loc.gov/standards/alto/ns-v3# http://www.loc.gov/standards/alto/v3/alto-3-1.xsd\" SCHEMAVERSION=\"3.1\"" +
                      " xmlns:xlink=\"http://www.w3.org/1999/xlink\">" +
                     "</alto>";
                XDocument doc = XDocument.Parse(xml);
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                XNamespace nsXsi = root.GetNamespaceOfPrefix("xsi");
                XNamespace nsSchemaLocation = root.GetNamespaceOfPrefix("schemaLocation");
                XNamespace nsXlink = root.GetNamespaceOfPrefix("xlink");
            }
        }
    }
