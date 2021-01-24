    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication55
    {
        class Program
        {
           
            static void Main(string[] args)
            {
                string header = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                    "<soap12:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap12=\"http://www.w3.org/2003/05/soap-envelope\">" +
                    "</soap12:Envelope>";
                XDocument doc = XDocument.Parse(header);
                XElement envelope = doc.Root;
                XNamespace nsSoap12 = envelope.GetNamespaceOfPrefix("soap12");
                XElement body = new XElement(nsSoap12 + "Body");
                envelope.Add(body);
            }
      
        }
