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
                string word = "computer";
                List<XElement> computers = doc.Descendants("entry").Where(x => (string)x.Attribute("id") == word).ToList();
                var definitions = computers.Select(x => new {
                    word = (string)x.Attribute("id"),
                    definitions = x.Elements("def").Select(y => new {
                        dts = y.Elements("dt").Select(z => (string)z).ToList()
                    }).FirstOrDefault()
                }).ToList();
            }
        }
    }
