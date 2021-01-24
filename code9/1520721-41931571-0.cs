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
                    "<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"" +
                         " xmlns:x=\"urn:schemas-microsoft-com:office:excel\"" +
                         " xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"" +
                         " xmlns:html=\"http://www.w3.org/TR/REC-html40\">" +
                    "</Workbook>";
                XDocument doc = XDocument.Parse(xml);
                XElement workbook = (XElement)doc.FirstNode;
                XNamespace ssNs = workbook.GetNamespaceOfPrefix("ss");
                XElement worksheet = new XElement(ssNs + "Worksheet");
                workbook.Add(worksheet);
            }
        }
    }
