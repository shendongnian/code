    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                //read file into string
                
                string xml = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(xml);
                var payment_methods = doc.Descendants("payment_method").Select(x => new {
                    code = (string)x.Element("code"),
                    name = (string)x.Element("name"),
                    test_mode = (Boolean)x.Element("test_mode")
                }).ToList();
            }
        }
    }
