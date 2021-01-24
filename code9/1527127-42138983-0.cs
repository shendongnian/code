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
                    "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + 
                    "<hibernate-mapping xmlns=\"urn:nhibernate-mapping-2.2\" assembly=\"AppNS\" namespace=\"AppNS\">" +
                    "</hibernate-mapping>";
                Product.products = new List<Product>() {
                    new Product() { Id = 100, Name = "Product", Services = new List<Service>() {
                        new Service() {Id = 1, Name = "Option 1"},
                        new Service() {Id = 2, Name = "Option 2"},
                        new Service() {Id = 4, Name = "Option 3"},
                        new Service() {Id = 8, Name = "Option 4"}
                    }}
                };
                XDocument serviceXml = XDocument.Parse(header);
                XElement mapping = (XElement)serviceXml.FirstNode;
                foreach(Product product in Product.products)
                {
                    XElement newProduct = new XElement("class");
                    mapping.Add(newProduct);
                    newProduct.Add(new object[] {
                        new XAttribute("name",product.Name),
                        new XAttribute("table","Product"),
                        new XElement("id", new object[] {
                            new XAttribute("name", product.Id),
                            new XAttribute("column", product.Id),
                            new XAttribute("type","int"),
                            new XElement("generator", new XAttribute("class","native"))
                        }),
                        new XElement("property", new object[] {
                            new XAttribute("name","Name"),
                            new XAttribute("column", "Name"),
                            new XAttribute("type","string")
                        })
                    });
                    XElement services = new XElement("class", new object[] {
                        new XAttribute("name", "Service"),
                        new XAttribute("table", "Service")
                    });
                    newProduct.Add(services);
                    foreach (Service service in product.Services)
                    {
                        services.Add(new XElement("id", new object[] {
                            new XAttribute("name", service.Name),
                            new XAttribute("column", service.Id),
                            new XAttribute("type", "int"),
                            new XElement("generator", new XAttribute("class","native"))
                        }));
                    }
                }
            }
        }
        public class Product
        {
            public static List<Product> products = new List<Product>();
            public virtual int Id { get; set; }
            public virtual string Name { get; set; }
            public virtual IList<Service> Services { get; set; }
        }
        public class Service
        {
            public virtual int Id { get; set; } // bit values: 1, 2, 4, 8, ...
            public virtual string Name { get; set; }
        }
    }
