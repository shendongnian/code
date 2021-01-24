    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication16
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XNamespace ns = doc.Root.GetNamespaceOfPrefix("x");
                EventRecord record = doc.Descendants(ns + "EventRecord").Select(x => new EventRecord() {
                    EventID = (string)x.Attribute("eventid"),
                    Postcode = (string)x.Descendants(ns + "ID").FirstOrDefault()
                }).FirstOrDefault();
            }
        }
        public class EventRecord
        {
            public string EventID { get; set; }
            public string Postcode { get; set; }
        }
    }
