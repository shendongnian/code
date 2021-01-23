    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication29
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<rootparent>" +
                        "<root>" +
                         "<parent>" +
                          "<child id=\"child_1\">" +
                          "</child>" +
                          "<child id=\"child_2\">" +
                          "</child>" +
                         "</parent" +
                        "</root>" +
                   "</rootparent>";
                XDocument doc = XDocument.Parse(xml);
                List<XElement> children = doc.Descendants("child").Where(x => ((string)x.Attribute("id")).StartsWith("child_")).ToList();
     
            }
     
        }
        
    }
