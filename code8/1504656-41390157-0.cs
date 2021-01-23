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
                XElement art = doc.Descendants("art").Where(x => (string)x.Attribute("code") == "0356").FirstOrDefault();
                art.SetAttributeValue("instock", "456");
                doc.Save(FILENAME);
            }
        }
    }
