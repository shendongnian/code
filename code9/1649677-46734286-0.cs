    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace Certificate
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(xml);
                XElement soap = doc.Root;
                XNamespace ns = soap.GetNamespaceOfPrefix("ns-wp");
                List<Trailer> trailers = doc.Descendants(ns + "Trailer").Select(x => new Trailer()
                {
                    trailerId = (string)x.Element(ns + "TrailerId"),
                    trailerType = (string)x.Element(ns + "TrailerType")
                }).ToList();
            }
     
        }
        public class Trailer
        {
            public string trailerId { get; set; }
            public string trailerType { get;set;}
     
        }
    }
