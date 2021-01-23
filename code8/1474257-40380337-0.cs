    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication23
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement invoice = (XElement)doc.Descendants().Where(x => x.Name.LocalName == "Invoice").FirstOrDefault();
                XNamespace cacNs = invoice.GetNamespaceOfPrefix("cac");
                XElement newInvoice = new XElement(cacNs + "InvoiceLine");
                invoice.Add(newInvoice);
            }
        }
    }
