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
                List<XElement> segments = doc.Descendants().Where(x => x.Name.LocalName == "seg").ToList();
                List<XElement> created = segments.Descendants().Where(x => (x.Name.LocalName == "value") && ((string)x.Attribute("key") == "Created")).ToList();
                string results = string.Join("\n", created.Select(x => (string)x));
            }
        }
    }
