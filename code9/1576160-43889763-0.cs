    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication50
    {
        class Program
        {
            static void Main(string[] args)
            {
                   
                    //<?xml version="1.0"?>
                    //<active_conditions>
                    //  <condition id="12323" name="Sunny"/>
                    //  <condition id="13323" name="Warm"/>
                    //</active_conditions>
                string header = "<?xml version=\"1.0\"?><active_conditions></active_conditions>";
                XDocument doc = XDocument.Parse(header);
                XElement activeCondition = (XElement)doc.FirstNode;
                activeCondition.Add(new object[] { 
                    new XElement("condition", new object[] {
                        new XAttribute("id", 12323),
                        new XAttribute("name", "Sunny")
                    }),
                    
                    new XElement("condition", new object[] {
                        new XAttribute("id", 13323),
                        new XAttribute("name", "Warm")
                    })
                });
                string xml = doc.ToString();
                XDocument doc2 = XDocument.Parse(xml);
                var results = doc2.Descendants("condition").Select(x => new
                {
                    id = x.Attribute("id"),
                    name = x.Attribute("name")
                }).ToList();
            }
        }
    }
