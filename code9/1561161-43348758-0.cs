    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication49
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("new").Select(x => new {
                    company = (string)x.Element("Company"),
                    dateTime = (DateTime)x.Element("DateTime"),
                    message = (string)x.Element("Message"),
                    status = (string)x.Element("Status")
                }).ToList();
            }
        }
    }
