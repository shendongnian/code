    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        public class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            public static void Main()
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement dictionary = doc.Descendants().Where(x => x.Name.LocalName == "Dictionary").FirstOrDefault();
                XNamespace xNs = dictionary.GetNamespaceOfPrefix("x");
                var results = dictionary.Descendants(xNs + "Int32").Select(x => (int)x).ToList();
     
            }
        }
    }
