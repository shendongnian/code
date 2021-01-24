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
            const string FILEMNAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILEMNAME);
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                Dictionary<string, string> dict = root.Descendants(ns + "InfoItem")
                    .GroupBy(x => (string)x.Element(ns + "Name"), y => (string)y.Element(ns + "Value"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
