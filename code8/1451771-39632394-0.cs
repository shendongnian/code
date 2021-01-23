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
                var results = doc.Descendants("CodeSample").Where(x => (string)x.Attribute("language") == "vba").Select(x => new {
                    parameters = x.Descendants("Parameter").Select(y => new {
                        parameterType = (string)y.Attribute("parameterType"),
                        parameterName = (string)y.Attribute("parameterName")
                    }).ToList(),
                    codeLines = (string)x.Element("CodeLines")
                }).ToList();
            }
        }
    }
