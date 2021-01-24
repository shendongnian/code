    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication63
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument .Load(FILENAME);
                Dictionary<string, string> dict = doc.Descendants("Attribute")
                    .GroupBy(x => (string)x.Element("Name"), y => (string)y.Element("Value"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
