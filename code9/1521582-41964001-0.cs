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
                 var groups = doc.Descendants("Group").Select(x => new {
                    lists = x.Elements("List").Select(y => new {
                        url = (string)y.Attribute("Url"),
                        list = y
                    })
                    .Select(z => new { name = (string)x.Attribute("Name"), list = z.list, url = (string)z.url})
                 }).SelectMany(y => y.lists).GroupBy(x => x.url).ToList();
            }
        }
    }
