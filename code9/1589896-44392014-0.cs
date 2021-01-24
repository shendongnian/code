    using System.Collections.ObjectModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication57
    {
        class Program
        {
            const string URL = "http://goalserve.com/samples/soccer_inplay.xml";
            static void Main(string[] args)
            {
                string xml =
                    "<ArrayOfAspect xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\">" +
                        "<Aspect i:type=\"TransactionAspect\">" +
                       "</Aspect>" +
                        "<Aspect i:type=\"TransactionAspect\">" +
                        "</Aspect>" +
                    "</ArrayOfAspect>";
                XDocument doc = XDocument.Parse(xml);
                XElement root = doc.Root;
                XNamespace nsI = root.GetNamespaceOfPrefix("i");
                root.Add(new XElement("Aspect", new object[] {
                    new XAttribute(nsI + "type", "TransactionAspect"),
                    new XElement("Value", "$VALUES_PLACEHOLDER$")
                }));
     
            }
        }
    }
