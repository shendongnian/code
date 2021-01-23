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
                Element1 elements = doc.Descendants("Element2").Select(x => new Element1() {
                    id = (string)x.Element("ElementID") == "" ? null : (int?)x.Element("ElementID"),
                    Element3aId = x.Descendants("Element3a").Select(y => new Element3a {
                        id =  (string)y.Attribute("id"),
                        Element3aId = (string)y.Element("Element3aId") == "" ? null : (int?)y.Element("Element3aId")
                    }).ToList(),
                    Element3bId = x.Descendants("Element3b").Select(y => new Element3a {
                        id =  (string)y.Attribute("id"),
                        Element3aId = (string)y.Element("Element3bId") == "" ? null : (int?)y.Element("Element3bId")
                    }).ToList(),
                    Element3cId = x.Descendants("Element3c").Select(y => new Element3a
                    {
                        id = (string)y.Attribute("id"),
                        Element3aId = (string)y.Element("Element3cId") == "" ? null : (int?)y.Element("Element3cId")
                    }).ToList()
                }).FirstOrDefault();
            }
        }
        public struct Element3a
        {
            public string id;
            public int? Element3aId;
        }
        public struct Element1
        {
            public int? id;
            public List<Element3a> Element3aId;
            public List<Element3a> Element3bId;
            public List<Element3a> Element3cId;
        }
    }
