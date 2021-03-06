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
            const string URL = "https://pastebin.com/raw/Ch1BeS0k";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(URL);
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                var results = root.Descendants(ns + "DataObject").Select(x => new
                {
                    date = (DateTime)x.Element(ns + "Date"),
                    hour = (int)x.Descendants(ns + "Hour").FirstOrDefault(),
                    time = (string)x.Descendants(ns + "Time").FirstOrDefault(),
                    runtime = (string)x.Descendants(ns + "Runtime").FirstOrDefault(),
                    displayText = x.Descendants(ns + "LogEvent").Where(y => (y.Element(ns + "AssetEvent") != null) && (y.Descendants(ns + "Runtime").Any())).Select(y => (string)y.Descendants(ns + "DisplayText").FirstOrDefault()).FirstOrDefault()
                }).FirstOrDefault();
            }
        }
    }
