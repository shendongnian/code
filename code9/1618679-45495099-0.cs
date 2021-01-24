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
                XElement startLayout = doc.Descendants().Where(x => x.Name.LocalName == "StartLayout").FirstOrDefault();
                var results = startLayout.Elements().Where(x => x.Name.LocalName == "Group").Select(x => new {
                    name = (string)x.Attribute("Name"),
                    tiles = x.Elements().Select(y => new {
                        size= (string)y.Attribute("Size"),
                        column = (int)y.Attribute("Column"),
                        row = (int)y.Attribute("Row"),
                        modelId = (string)y.Attribute("AppUserModelID"),
                        appId = (string)y.Attribute("DesktopApplicationID")
                    }).ToList()
                }).ToList();
            }
        }
    }
