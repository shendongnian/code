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
                Dictionary<string,string> dict1 = doc.Descendants("NameValuePair")
                    .GroupBy(x => (string)x.Element("Name"), y => (string)y.Element("Value"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                //or if you have multiple values for same key
                Dictionary<string, List<string>> dict12 = doc.Descendants("NameValuePair")
                    .GroupBy(x => (string)x.Element("Name"), y => (string)y.Element("Value"))
                    .ToDictionary(x => x.Key, y => y.ToList());
            }
        }
    }
