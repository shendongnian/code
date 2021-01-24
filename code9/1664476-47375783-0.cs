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
                XElement settings = doc.Root;
                List<XElement> children = settings.Elements().ToList();
                settings.Descendants().Remove();
                settings.Add(new XElement("ThisSettings", children));
            }
        }
    }
