    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication43
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("testresult").Select(x => new {
                    result = x.Elements("result").Select(y => new {
                        value = (int)y.Attribute("value"),
                        name = (string)y.Attribute("name"),
                        text = (int)y
                    }).ToList()
                }).ToList();
            }
        }
    }
