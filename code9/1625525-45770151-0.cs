    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                reader.ReadLine(); //skip the identification line with utf-16
                XElement doc = XElement.Load(reader);
                List<string> text = doc.Descendants().Where(x => x.Name.LocalName == "DisplayName").Select(x => (string)x.Attribute("Text")).ToList();
            }
        }
    }
