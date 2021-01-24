    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication48
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement root = doc.Elements("Root").FirstOrDefault();
                List<XElement> descendants = root.Elements().ToList();
                descendants = descendants.OrderBy(x => (string)x.Descendants("code").FirstOrDefault()).ToList();
                root.ReplaceNodes(descendants);
            }
        }
    }
