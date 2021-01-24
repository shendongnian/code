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
                var dates = doc.Descendants().Where(x => x.Name.LocalName.Contains("Date") && ((string)x != string.Empty));
                foreach (var date in dates)
                {
                    date.SetValue(((DateTime)date).ToUniversalTime());
                }
            }
        }
    }
