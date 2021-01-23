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
                var results = doc.Descendants("PLC").Select(x => new {
                    name = (string)x.Attribute("Name"),
                    ipAddress = (string)x.Element("PLCInfo").Attribute("IPAddress"),
                    tags = x.Descendants("Tag").Select(y => new {
                            name = (string)y.Attribute("TagName"),
                            type = (string)y.Attribute("DataType"),
                            size = (int)y.Attribute("ElemSize"),
                            count = (int)y.Attribute("ElemCount")
                    }).ToList()
                }).ToList();
            }
        }
    }
