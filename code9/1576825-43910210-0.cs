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
                string dateStr = "2018-04-15T00:00:00";
                var dates = doc.Descendants().Where(x => x.Name.LocalName.Contains("Date"));
                foreach (var date in dates)
                {
                    date.SetValue(dateStr);
                }
            }
        }
    }
