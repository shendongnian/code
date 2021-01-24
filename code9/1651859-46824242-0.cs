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
                XElement root = doc.Root;
                XNamespace ns = root.GetNamespaceOfPrefix("v1");
                var results = root.Descendants(ns + "Field").Select(x => new Field() {
                    type = (string)x.Attribute("type"),
                    name = (string)x.Element(ns + "name"),
                    category = (string)x.Element(ns + "category"),
                    mandatory = (string)x.Element(ns + "mandatory"),
                    alias = (string)x.Element(ns + "alias"),
                    value = (string)x.Element(ns + "value"),
                }).FirstOrDefault();
            }
        }
        public class Field
        {
            public string type { get; set; }
            public string name { set; get; }
            public string category { set; get; }
            public string mandatory { set; get; }
            public string alias { set; get; }
            public string value { set; get; }
        }
    }
