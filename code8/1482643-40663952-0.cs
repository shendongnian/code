    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication28
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();
                XDocument doc = XDocument.Load(FILENAME);
                XElement someId = doc.Descendants("someId").FirstOrDefault();
                dict = someId.Elements().GroupBy(x => x.Name.LocalName, y => (int)y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
