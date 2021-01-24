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
                var message = doc.Descendants().Where(x => x.Name.LocalName == "message").Select(x => new {
                    to = (string)x.Attribute("to"),
                    type = (string)x.Attribute("type"),
                    lang = (string)x.Attributes().Where(y => y.Name.LocalName == "lang").FirstOrDefault(),
                    from = (string)x.Attribute("from"),
                    messages = x.Elements().Select(y => new {
                        name = y.Name.LocalName,
                        id = (string)y.Attribute("id"),
                        by = (string)y.Attribute("by"),
                        value = (string)y
                    }).ToList()
                }).FirstOrDefault();
            }
        }
    }
