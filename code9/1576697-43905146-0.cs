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
                var resuts = doc.Descendants("area").Where(x => (int)x.Attribute("level") == 1).Elements().Select(x => new {
                    name = x.Name.LocalName,
                    value = (string)x
                }).ToList();
            }
        }
    }
