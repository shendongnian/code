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
            const string URL = @"https://badgag.com/sitemap.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(URL);
                XNamespace ns = doc.Root.GetDefaultNamespace();
                string[] locations = doc.Descendants(ns + "loc").Select(x => (string)x).ToArray();
            }
        }
    }
