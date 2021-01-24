    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(xml);
                XNamespace creNs = doc.Root.GetNamespaceOfPrefix("cre");
                XNamespace soapNs = doc.Root.GetNamespaceOfPrefix("soapenv");
                XNamespace defaultNs = doc.Root.GetDefaultNamespace();
                string operation = "Purchase";
                DateTime now = DateTime.Now;
                string  token = "12345";
                string name = "John Smith";
                string bank = "BOA";
                string message = "Paid in Full";
                
                XElement header = doc.Descendants(soapNs + "Header").FirstOrDefault();
                header.SetElementValue(creNs + "paymentOperation",operation);
                header.SetElementValue(creNs + "requestTimeStamp", now);
                header.SetElementValue(creNs + "securityToken", token);
                XElement body = doc.Descendants(soapNs + "Body").FirstOrDefault();
                XElement createPayment = body.Element(creNs + "createPayment");
                createPayment.SetElementValue(defaultNs + "remitterBankBIC", bank);
                createPayment.SetElementValue(defaultNs + "requestMsg", message);
            }
        }
    }
