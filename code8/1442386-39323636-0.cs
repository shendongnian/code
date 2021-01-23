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
                string xmlHeader = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                    "<Root xmlns:me =\"abc\" xmlns:asp =\"def\"></Root>";
                XDocument doc = XDocument.Parse(xmlHeader);
                XElement root = (XElement)doc.FirstNode;
                XNamespace meNs = root.GetNamespaceOfPrefix("me");
                XNamespace aspNs = root.GetNamespaceOfPrefix("asp");
                XElement control = new XElement(meNs + "MyControl");
                root.Add(control);
                var inputs = new[] {
                   new { PropertyA="Hello", PropertyB="World", Id="Test"},
                   new { PropertyA="Foo", PropertyB="Bar", Id="Test"},
                };
                foreach (var input in inputs)
                {
                    control.Add(new XElement("TemplateA", new object[] {
                        new XAttribute("PropertyA", input.PropertyA),
                        new XAttribute("PropertyB", input.PropertyB),
                        new XElement(aspNs + "Textbox", new XAttribute("Id", input.Id))
                     }));
                }
            }
        }
    }
