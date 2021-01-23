    using System;
    using System.Xml.Linq;
    
    public class Test
    {
        static void Main()
        {
            XNamespace ns = "http://www.w3.org/2001/XMLSchema-instance";
            XDocument doc = new XDocument(
                new XElement("root",
                    new XAttribute(XNamespace.Xmlns + "xsi", ns.NamespaceName),
                    new XElement("element1", new XAttribute(ns + "schema", "s1")),
                    new XElement("element2", new XAttribute(ns + "schema", "s2"))
                )                         
            );
            Console.WriteLine(doc);
        }
    }
