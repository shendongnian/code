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
                    "<level1>" +
                        "<level2>" +
                              "<coolstuff name=\"name\"/>" +
                        "</level2>" +
                    "</level1>";
                XDocument doc = XDocument.Parse(xml);
                XElement level2 = doc.Descendants("level2").FirstOrDefault();
                level2.Add(new XElement("stupidtags", new object[] {
                        new XElement("stupidtag", new object[] {
                        new XAttribute("name", "stupidname")
                    })
                }));
            }
        }
    }
