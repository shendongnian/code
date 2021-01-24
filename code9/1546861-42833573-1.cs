    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication48
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement root = doc.Elements("root").FirstOrDefault();
                List<XElement> products = root.Elements("Product").ToList();
                for (int i = products.Count() - 1; i >= 0; i--)
                {
                    XElement product = products[i];
                    List < XElement > newProducts = new List<XElement>();
                    if (product.Elements("category").Count() > 1)
                    {
                        foreach (XElement category in product.Elements("category"))
                        {
                            XElement newProduct = new XElement("Product", category);
                            newProducts.Add(newProduct);
                        }
                        product.ReplaceWith(newProducts);
                    }
                }
                List<XElement> descendants = root.Elements().ToList();
                descendants = descendants.OrderBy(x => (string)x.Descendants("code").FirstOrDefault()).ToList();
                root.ReplaceNodes(descendants);
            }
        }
    }
