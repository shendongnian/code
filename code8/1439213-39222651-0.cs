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
                XElement rdf = (XElement)doc.FirstNode;
                XNamespace rdfNs = rdf.GetNamespaceOfPrefix("rdf");
                XNamespace dcNs = rdf.GetNamespaceOfPrefix("dc");
                XNamespace defaultNs = rdf.GetDefaultNamespace();
                CraigslistRDF craigslistRDF = rdf.Elements(defaultNs + "channel").Select(x => new CraigslistRDF
                {
                    Channel = new CraigslistChannel() {
                        About = (string)x.Attribute(rdfNs + "about"),
                        Description = (string)x.Elements(defaultNs + "description").FirstOrDefault(),
                        Link =  (string)x.Element(defaultNs + "link"),
                        Title =  (string)x.Element(defaultNs + "title")
                    },
     
                }).FirstOrDefault();
                craigslistRDF.Items = rdf.Elements(defaultNs + "item").Select(x => new CraigslistItem()
                {
                    About = (string)x.Attribute(rdfNs + "about"),
                    Description = (string)x.Elements(defaultNs + "description").FirstOrDefault(),
                    Link = (string)x.Element(defaultNs + "link"),
                    Source = (string)x.Element(dcNs + "source"),
                    Title = (string)x.Element(defaultNs + "title")
                }).ToArray();
            }
        }
        
        public class CraigslistRDF
        {
            public CraigslistChannel Channel { get; set; }
            public CraigslistItem[] Items { get; set; }
        }
        public class CraigslistChannel
        {
            public String About { get; set; }
            public String Title { get; set; }
            public String Link { get; set; }
            public String Description { get; set; }
        }
        public class CraigslistItem
        {
            public String About { get; set; }
            public String Title { get; set; }
            public String Link { get; set; }
            public String Description { get; set; }
            public String Source { get; set; }
        }
    }
