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
                int count = 1;
                foreach (XElement entry in doc.Descendants("entry"))
                {
                    entry.SetAttributeValue("entryno", count++);
                }
            }
        }
    }
