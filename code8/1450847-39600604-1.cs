    using System;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    class Program
    {
        static void Main()
        {
            var doc = XDocument.Load("a.xml");
            var nsm = new XmlNamespaceManager(new NameTable());
            nsm.AddNamespace("x", "urn:hl7-org:v3");
            var patients = doc.XPathSelectElements("//x:patient", nsm);
            foreach (var patient in patients)
            {
                Console.WriteLine(patient.XPathSelectElement("./x:name/x:given[1]", nsm).Value);
                Console.WriteLine(patient.XPathSelectElement("./x:name/x:given[2]", nsm).Value);
                Console.WriteLine(patient.XPathSelectElement("./x:name/x:family", nsm).Value);
                Console.WriteLine(patient.XPathSelectElement("./x:birthTime", nsm).Attribute("value").Value);
            }
        }
    }
