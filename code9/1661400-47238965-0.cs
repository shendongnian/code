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
                XDocument xml = XDocument.Load(FILENAME);
                XElement parent = xml.Descendants("parent").FirstOrDefault();
                parent.Add(new object[] {
                    new XElement("course", "ABC"),
                    new XElement("credit",555)
                });
            }
        }
    }
