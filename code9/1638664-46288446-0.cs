    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication5
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> products = doc.Descendants("product").ToList();
                foreach (XElement product in products)
                {
                    product.Add(new XElement("product", new XAttribute("id", (string)product.Attribute("id"))));
                    product.ReplaceWith(new XElement("table", product.Descendants()));
                }
            }
        }
    }
