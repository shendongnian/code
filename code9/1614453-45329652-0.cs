    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication68
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml = "<root>" +
                                "<a>" +
                                    "<child1 Id=\"Id1\" Name=\"Name1\" />" +
                                    "<child2 Id=\"Id2\" Name=\"Name2\" />" +
                                "</a>" +
                            "</root>";
                XDocument doc = XDocument.Parse(xml);
                Dictionary<string, string> dict = doc.Descendants("a").FirstOrDefault().Elements().Where(x => x.Name.LocalName.StartsWith("child"))
                    .GroupBy(x => (string)x.Attribute("Id"), y => (string)y.Attribute("Name"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                    
            }
        }
     
    }
