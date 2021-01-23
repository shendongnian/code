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
                XNamespace ns = ((XElement)doc.FirstNode).Name.Namespace;
                Document.documents  = doc.Descendants(ns + "par").Select(x => new Document() {
                    lineSpacing = (int?)x.Attribute("lineSpacing"),
                    lines = x.Elements(ns + "line").Select(y => new Line() {
                        baseline = (int)y.Attribute("baseline"),
                        l = (int)y.Attribute("l"),
                        t = (int)y.Attribute("t"),
                        r = (int)y.Attribute("r"),
                        b = (int)y.Attribute("b"),
                        formatting = (string)y.Element(ns + "formatting"),
                        lang = (string)y.Element(ns + "formatting").Attribute("lang")
                    }).ToList()
                }).ToList();
            }
        }
        public class Document
        {
            public static List<Document> documents = new List<Document>();
            public int? lineSpacing { get; set; }
            public List<Line> lines { get; set; }
        }
        public class Line
        {
            public int baseline { get; set; }
            public int l { get; set; }
            public int t { get; set; }
            public int r { get; set; }
            public int b { get; set; }
            public string formatting { get; set; }
            public string lang { get; set; }
        }
    }
