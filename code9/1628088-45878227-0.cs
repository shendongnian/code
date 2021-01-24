    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication74
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Dictionary<string,int?> dict1 = doc.Descendants("Field")
                    .GroupBy(x => (string)x.Attribute("Name"), y => string.IsNullOrEmpty((string)y.Element("Value")) ? null : (int?)y.Element("Value"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
         
     
    }
