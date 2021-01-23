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
                XElement _default = doc.Descendants("Default").FirstOrDefault();
                int defaultPort = (int)_default.Element("Port");
                string defaultFileLocation = (string)_default.Element("FileLocation");
                var files = doc.Descendants("File").Select(x => new {
                    type = (string)x.Element("Type"),
                    fileName = (string)x.Element("FileName"),
                    port = (string)x.Element("Port") == "" ? defaultPort : (int)x.Element("Port"),
                    fileLocation = (string)x.Element("FileLocation") == "" ? defaultFileLocation : (string)x.Element("FileLocation"),
                }).ToList();
            }
        }
    }
