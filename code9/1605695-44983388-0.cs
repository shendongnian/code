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
                Dictionary<string, int> dict = doc.Descendants("ResultTest").Elements()
                    .GroupBy(x => x.Name.LocalName, y => (int)y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
