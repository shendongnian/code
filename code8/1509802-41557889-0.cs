    using System;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main(string[] args)
        {
            XNamespace xdt = "http://schemas.microsoft.com/XML-Document-Transform";
    
            XDocument doc = new XDocument(
                new XElement("configuration",
                    new XAttribute(XNamespace.Xmlns + "xdt", xdt.NamespaceName),
                    new XElement("appSettings",
                        new XElement("add",
                            new XAttribute("key", "WriteToLogFile"),
                            new XAttribute("value", true),
                            new XAttribute(xdt + "Transform", "SetAttributes(value)"),
                            new XAttribute(xdt + "Locator", "Match(name)")
                        )
                    )
                )
            );
            Console.WriteLine(doc);
        }    
    }
