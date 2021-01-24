    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication49
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                reader.ReadLine(); //skip the xml identification with utf-16 encoding
                XDocument doc = XDocument.Load(reader);
                XElement firstNode = (XElement)doc.FirstNode;
                XNamespace nsXs = firstNode.GetNamespaceOfPrefix("xs");
                XElement sequence = doc.Descendants(nsXs + "element").FirstOrDefault();
                sequence.Add(new XElement(nsXs + "annotation",
                    new XElement(nsXs + "documention", "Will need to be greater than 0 to walk!")
                    ));
                
            }
        }
     
       
    }
