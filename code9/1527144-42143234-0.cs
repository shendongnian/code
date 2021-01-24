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
                    "<Root>" +
                       "<Person>" +
                          "<Programmer/>" +
                          "<Teacher/>" +
                       "</Person>" +
                    "</Root>";
                XElement root = XElement.Parse(xml);
                string[] persons = root.Descendants("Person").Elements().Select(x => x.Name.LocalName).ToArray();
            }
        }
    }
