    using System.Collections.ObjectModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication57
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Dictionary<string,string> dict = doc.Descendants("String")
                    .GroupBy(x => (string)x.Attribute("Target"), y => (string)y.Attribute("Link"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
            
        }
     
    }
