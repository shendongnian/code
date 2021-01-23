    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication31
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument xdoc = XDocument.Load(FILENAME);
                var results = xdoc.Elements("root").Select(x => new
                {
                    ns = x.Descendants("n").Select(y => new {
                        id = (long)y.Attribute("id"),
                        l = (double)y.Attribute("l"),
                        b = (double)y.Attribute("b")
                    }).ToList(),
                    ws = x.Descendants("w").Select(y => new {
                        id = (long)y.Attribute("id"),
                        rfs= y.Descendants("nd").Select(z => (long)z.Attribute("rf")).ToList()
                    }).ToList()
                }).FirstOrDefault();
            }
        }
     
    }
