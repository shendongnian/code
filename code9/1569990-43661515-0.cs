    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication50
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test2.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Dictionary<string, XElement> dict = doc.Descendants("ElementData").GroupBy(x => (string)x.Attributes().Where(y => y.Name.LocalName == "type").FirstOrDefault(), z => z)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                XElement SecondElement = dict["SecondElement"];
                SecondElement.Element("Description").SetValue("abcd");
            }
        }
        
        
    }
