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
            const string FILENAME = @"c:\temp\test2.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Test test1 = doc.Descendants("building")
                    .Where(x => (int)x.Element("id") == 1)
                    .Select(x => new Test() {
                        name = (string)x.Element("name"),
                        id = (int)x.Element("id"),
                        build_time = (int)x.Element("build_time"),
                        time_factor = (double)x.Element("time_factor")
                    }).FirstOrDefault();
            }
        }
        public class Test
        {
            public string name { get; set; }
            public int id { get; set; }
            public int build_time { get; set; }
            public double time_factor { get; set; }
        }
    }
