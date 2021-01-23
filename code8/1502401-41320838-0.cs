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
                Dictionary<string, string> dict1 = doc.Descendants("setting").Select(x => new {
                    name = (string)x.Attribute("name"),
                    value = (string)x.Element("value")
                }).GroupBy(x => x.name, y => y.value)
                .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                Dictionary<string, List<string>> dict2 = doc.Descendants("setting").Select(x => new {
                    name = (string)x.Attribute("name"),
                    value = (string)x.Element("value")
                }).GroupBy(x => x.name, y => y.value)
                .ToDictionary(x => x.Key, y => y.ToList());
            }
        }
    }
