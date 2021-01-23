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
                var results = doc.Elements().Select(x => new {
                    property1 = x.Elements("property1").Select(y => (string)y).ToList(),
                    dictCurrency = x.Elements("amount").Elements().GroupBy(y => y.Name.LocalName, z => (int)z)
                       .ToDictionary(y => y.Key, z => z.FirstOrDefault())
                }).FirstOrDefault();
            }
        }
    }
