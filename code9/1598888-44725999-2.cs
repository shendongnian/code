    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication63
    {
        class Program
        {
            const string XML_FILENAME = @"c:\temp\test.xml";
            const string CSV_FILENAME = @"c:\temp\test.csv";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(XML_FILENAME);
                Dictionary<string, string> dict = doc.Descendants("Attribute")
                    .GroupBy(x => (string)x.Element("Name"), y => (string)y.Element("Value"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                StreamWriter writer = new StreamWriter(CSV_FILENAME);
                foreach (KeyValuePair<string, string> row in dict.AsEnumerable())
                {
                      writer.WriteLine(string.Join(",", new string[] {row.Key, row.Value}));
                }
                writer.Flush();
                writer.Close();
            }
        }
    }
