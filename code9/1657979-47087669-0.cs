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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement salesOrder = doc.Descendants("SalesOrders").FirstOrDefault();
                List<XElement> children = salesOrder.Elements().ToList();
                XElement order = null;
                foreach (XElement child in children)
                {
                    if (child.Name.LocalName == "Header")
                    {
                        order = new XElement("Order");
                        salesOrder.Add(order);
                    }
                    order.Add(child);
                    child.Remove();
                }
            }
        }
    }
