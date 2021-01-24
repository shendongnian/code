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
                        "<ABC>" +
                            "<a>info</a>" +
                        "</ABC>";
                XDocument doc = XDocument.Parse(xml);
                XElement root = doc.Root;
                root.ReplaceWith(new XElement("X", root));
            }
        }
    }
