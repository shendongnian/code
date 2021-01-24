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
                XElement person = doc.Descendants().Where(x => x.Name.LocalName == "Person").FirstOrDefault();
                XNamespace ns = person.GetDefaultNamespace();
                Dictionary<string, string> dict = person.Elements()
                    .Where(x => x.Name.LocalName != "IdDocumentList")
                    .GroupBy(x => x.Name.LocalName, y => y == null? "" : (string)y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                foreach (XElement element in person.Descendants(ns + "IdDocument").FirstOrDefault().Elements())
                {
                    dict.Add(element.Name.LocalName, (string)element);
                }
            }
        }
    }
