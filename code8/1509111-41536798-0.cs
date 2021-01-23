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
                XElement messages = doc.Descendants().Where(x => x.Name.LocalName == "Messages").FirstOrDefault();
                XNamespace ns = messages.GetDefaultNamespace();
                List<string> strMessages = messages.Elements(ns + "Message").Select(x => (string)x).ToList();
            }
        }
    }
