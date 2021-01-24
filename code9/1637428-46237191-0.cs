    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication4
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static List<XElement> nodes;
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement feed = doc.Root;
                XNamespace ns = feed.GetDefaultNamespace();
                foreach (XElement entry in feed.Elements(ns + "entry"))
                {
                    Entry newEntry = new Entry();
                    Entry.entries.Add(newEntry);
                    newEntry.title = (string)entry.Element(ns + "title");
                    newEntry.end_x0020_Use = (string)entry.Descendants().Where(x => x.Name.LocalName == "End_x0020_Use").FirstOrDefault();
                    newEntry.approval_x0020_Type = (string)entry.Descendants().Where(x => x.Name.LocalName == "Approval_x0020_Type").FirstOrDefault();
                    newEntry.links = entry.Elements(ns + "link").Select(x => x.Descendants().Where(y => y.Name.LocalName == "entry").Select(y => new Link() {
                       name = (string)y.Descendants().Where(z => z.Name.LocalName == "name").FirstOrDefault(),
                       id = (string)y.Descendants().Where(z => z.Name.LocalName == "id").FirstOrDefault(),
                       email = (string)y.Descendants().Where(z => z.Name.LocalName == "EMail").FirstOrDefault(),
                       title = (string)x.Attributes().Where(z => z.Name.LocalName == "title").FirstOrDefault()
                    }).FirstOrDefault()
                    ).ToList();
                }
            }
     
        }
        public class Entry
        {
            public static List<Entry> entries = new List<Entry>();
            public string title { get; set;}
            public string end_x0020_Use { get; set; }
            public string approval_x0020_Type { get; set; }
            public List<Link> links { get; set; }
        }
        public class Link
        {
            public string name { get; set; }
            public string id { get; set; }
            public string title { get; set; }
            public string email { get; set; }
        }
     
    }
     
