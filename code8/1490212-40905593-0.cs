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
                string header =
                "<inventory_report:inventoryReportMessage xmlns:inventory_report=\"urn:gs1:ecom:inventory_report:xsd:3\" xmlns:sh=\"http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader\" xmlns:ecom_common=\"urn:gs1:ecom:ecom_common:xsd:3\" xmlns:shared_common=\"urn:gs1:shared:shared_common:xsd:3\">" +
                  "<sh:StandardBusinessDocumentHeader>" +
                    "<sh:HeaderVersion>Standard Business Header version 1.3</sh:HeaderVersion>" +
                    "<sh:Sender>" +
                    "</sh:Sender>" +
                  "</sh:StandardBusinessDocumentHeader>" +
                "</inventory_report:inventoryReportMessage>";
                XDocument doc = XDocument.Parse(header);
                XElement sender = doc.Descendants().Where(x => x.Name.LocalName == "Sender").FirstOrDefault();
                XNamespace shNs = sender.GetNamespaceOfPrefix("sh");
                sender.Add(new XElement(shNs + "Identifier", new object[] {
                    new XAttribute("Authority", "GS1"),
                    "0000"
                }));
                sender.Add(    new XElement(shNs + "ContactInformation", new object[] {
                        new XElement(shNs + "Contact", "some one"),
                        new XElement(shNs + "EmailAddress", "someone@example.com"),
                        new XElement(shNs + "TelephoneNumber", "00357"),
                        new XElement(shNs + "ContactTypeOdemtofier", "IT Support")
                }));
            }
        }
    }
