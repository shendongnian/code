    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication49
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Dictionary<string, string> nameValue = doc.Descendants("NameValueList")
                    .GroupBy(y => (string)y.Element("Name"), z => (string)z.Element("Value"))
                    .ToDictionary(y => y.Key, z => z.FirstOrDefault());
            }
        }
    }
