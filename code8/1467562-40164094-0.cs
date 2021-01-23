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
                Data data = new Data();
                data.values = doc.Descendants("data").Select(x => new Values() {
                    returncode = (int?)x.Descendants("int").FirstOrDefault(),
                    token = (string)x.Descendants("string").FirstOrDefault()
                }).ToArray();
            }
        }
        public class Data
        {
            public Values[] values;
        }
        public class Values
        {
            public int? returncode;
            public string token;
        }
    }
